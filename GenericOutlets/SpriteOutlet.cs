using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DT {
  [Serializable]
  public struct SpriteOutlet {
    public Sprite Sprite {
      set { this.SetSprite(value); }
    }

    public void SetSprite(Sprite sprite) {
      if (this._spriteRenderer != null) {
        this._spriteRenderer.sprite = sprite;
      }

      if (this._image != null) {
        this._image.sprite = sprite;
      }
    }


    // PRAGMA MARK - Internal
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Image _image;
  }
}