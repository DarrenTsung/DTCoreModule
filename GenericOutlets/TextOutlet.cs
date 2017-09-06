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
			set { SetText(value); }
		}

		public void SetActive(bool active) {
			if (this._unityText != null) {
				this._unityText.gameObject.SetActive(active);
			}

			#if TMPRO
			if (this._tmpText != null) {
				this._tmpText.gameObject.SetActive(active);
			}
			#endif
		}

		public void SetText(string text) {
			if (this._unityText != null) {
				this._unityText.text = text;
			}

			#if TMPRO
			if (this._tmpText != null) {
				this._tmpText.text = text;
			}
			#endif
		}

		public Color Color {
			get { return GetColor(); }
			set { SetColor(value); }
		}

		public Color GetColor() {
			if (this._unityText != null) {
				return this._unityText.color;
			}

			#if TMPRO
			if (this._tmpText != null) {
				return this._tmpText.color;
			}
			#endif

			return Color.white;
		}

		public void SetColor(Color color) {
			if (this._unityText != null) {
				this._unityText.color = color;
			}

			#if TMPRO
			if (this._tmpText != null) {
				this._tmpText.color = color;
			}
			#endif
		}

		public void SetEnabled(bool enabled) {
			if (this._unityText != null) {
				this._unityText.enabled = enabled;
			}

			#if TMPRO
			if (this._tmpText != null) {
				this._tmpText.enabled = enabled;
			}
			#endif
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