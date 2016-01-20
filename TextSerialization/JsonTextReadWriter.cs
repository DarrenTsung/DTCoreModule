using DT;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  [CustomExtensionInspector]
  public class JsonTextReadWriter<T> : MonoBehaviour where T : JsonSerializable, new() {
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

    protected virtual void Awake() {
      this.ReadFromSource();
    }

    [MakeButton]
    protected void ReadFromSource() {
      this._data = JsonSerializable.DeserializeFromTextAsset<T>(this._textSource);
    }

    [MakeButton]
    protected void WriteToSource() {
      IStringSerializableUtil.WriteToTextSource(this._data, this._textSource);
    }
  }
  //
  // [Serializable]
  // public class SpawnerParameters : JsonSerializable {
  //   // PRAGMA MARK - Public Variables
  //   public List<SpawnObjectParameters> objectParameters;
  // }
  //
  // [Serializable]
  // public class SpawnObjectParameters {
  //   // PRAGMA MARK - Public Variables
  //   public float minAfterSpawnDelay;
  //   public float maxAfterSpawnDelay;
  //
  //   public string prefabName;
  //
  //   public int weight;
  // }
}