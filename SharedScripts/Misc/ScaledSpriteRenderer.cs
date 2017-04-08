using DT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT.Game {
	[RequireComponent(typeof(SpriteRenderer))]
	public class ScaledSpriteRenderer : MonoBehaviour {
		// PRAGMA MARK - Internal
		[SerializeField, ReadOnly]
		private Vector3 _size = Vector3.one;

		private Sprite cachedSprite_ = null;
		private SpriteRenderer spriteRenderer_;

		private SpriteRenderer SpriteRenderer_ {
			get {
				if (spriteRenderer_ == null) {
					spriteRenderer_ = GetComponent<SpriteRenderer>();
				}
				return spriteRenderer_;
			}
		}

		private void OnEnable() {
			MonoBehaviourWrapper.OnUpdate += HandleUpdate;
		}

		private void OnDisable() {
			MonoBehaviourWrapper.OnUpdate -= HandleUpdate;
		}

		private void OnDrawGizmos() {
			Gizmos.DrawWireCube(transform.position, _size);
		}

		private void HandleUpdate() {
			if (cachedSprite_ != SpriteRenderer_.sprite) {
				ResetSize();
				cachedSprite_ = SpriteRenderer_.sprite;
			}
		}

		private void ResetSize() {
			Vector3 baseSize = Vector3Util.InverseScale(SpriteRenderer_.bounds.size, transform.lossyScale);
			Vector3 scale = Vector3Util.InverseScale(_size, baseSize);
			transform.localScale = scale;
		}

		// TODO (darren): expose this in editor to change spriteRenderer
		private void SetSize() {
			_size = SpriteRenderer_.bounds.size;
		}
	}
}
