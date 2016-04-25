using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#if TMPRO
using TMPro;
#endif

namespace DT {
  [Serializable]
  public class TextController {
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


    // PRAGMA MARK - Internal
    [SerializeField]
    private Text _unityText;
#if TMPRO
    [SerializeField]
    private TMP_Text _tmpText;
#endif
  }
}