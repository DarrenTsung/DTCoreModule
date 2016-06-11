using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#if TMPRO
using TMPro;
#endif

namespace DT {
  [Serializable]
  public class TextOutlet {
    public string Text {
      set { this.SetText(value); }
    }

    public void SetText(string text) {
      if (this._unityText != null) {
        this._unityText.text = text;
      }

      if (this._tmpText != null) {
        this._tmpText.text = text;
      }
    }

    public Color Color {
      get { return this.GetColor(); }
      set { this.SetColor(value); }
    }

    public Color GetColor() {
      if (this._unityText != null) {
        return this._unityText.color;
      }

      if (this._tmpText != null) {
        return this._tmpText.color;
      }

      return Color.white;
    }

    public void SetColor(Color color) {
      if (this._unityText != null) {
        this._unityText.color = color;
      }

      if (this._tmpText != null) {
        this._tmpText.color = color;
      }
    }


    // PRAGMA MARK - Internal
    [SerializeField]
    private Text _unityText;
#if TMPRO
    [SerializeField]
    private TMP_Text _tmpText;
#endif
  }
}