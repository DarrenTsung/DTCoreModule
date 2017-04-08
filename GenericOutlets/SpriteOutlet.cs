using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DT {
	[Serializable]
	public struct SpriteOutlet {
		public Sprite Sprite {
			set { SetSprite(value); }
		}

		public void SetSprite(Sprite sprite) {
			if (this._spriteRenderer != null) {
				this._spriteRenderer.sprite = sprite;
			}

			if (this._image != null) {
				this._image.sprite = sprite;
			}
		}

		public Color Color {
			set { SetColor(value); }
		}

		public void SetColor(Color color) {
			if (this._spriteRenderer != null) {
				this._spriteRenderer.color = color;
			}

			if (this._image != null) {
				this._image.color = color;
			}
		}


		// PRAGMA MARK - Internal
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		[SerializeField]
		private Image _image;
	}
}