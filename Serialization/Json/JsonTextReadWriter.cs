using DT;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  [CustomInspector]
  public class JsonTextReadWriter<T> : MonoBehaviour where T : new() {
    // PRAGMA MARK - Internal
    protected T Data {
      get {
        return this._data;
      }
    }

    [SerializeField]
    private TextAsset _textSource;
    [SerializeField]
    private T _data = new T();

    // optional
    protected virtual void HandleDataUpdated() {}

    protected void SetTextSourceAndRead(TextAsset textSource) {
      this._textSource = textSource;
      this.ReadFromSource();
    }

    [MakeButton]
    protected void ReadFromSource() {
      if (this._textSource == null) {
        Debug.LogWarning("ReadFromSource - failed because text source is null!");
        return;
      }

      this._data = JsonSerialization.DeserializeFromTextAsset<T>(this._textSource);
      this.HandleDataUpdated();
    }

    [MakeButton]
    protected void WriteToSource() {
      if (this._textSource == null) {
        Debug.LogWarning("WriteToSource - failed because text source is null!");
        return;
      }

      if (this._data == null) {
        Debug.LogWarning("WriteToSource - failed because data is null!");
        return;
      }

      JsonSerialization.SerializeToTextAsset(this._data, this._textSource, prettyPrint: true);
    }
  }
}