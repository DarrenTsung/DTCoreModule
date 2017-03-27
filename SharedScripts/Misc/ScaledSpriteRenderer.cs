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
        [SerializeField, ReadOnly] private Vector3 _size = Vector3.one;

        private Sprite _cachedSprite = null;
        private SpriteRenderer _spriteRenderer;

        private SpriteRenderer _SpriteRenderer {
            get {
                if (_spriteRenderer == null) {
                    _spriteRenderer = GetComponent<SpriteRenderer>();
                }
                return _spriteRenderer;
            }
        }

        void OnEnable() {
            MonoBehaviourWrapper.OnUpdate += HandleUpdate;
        }

        void OnDisable() {
            MonoBehaviourWrapper.OnUpdate -= HandleUpdate;
        }

        void OnDrawGizmos() {
            Gizmos.DrawWireCube(transform.position, _size);
        }

        private void HandleUpdate() {
            if (_cachedSprite != _SpriteRenderer.sprite) {
                ResetSize();
                _cachedSprite = _SpriteRenderer.sprite;
            }
        }

        private void ResetSize() {
            Vector3 baseSize = Vector3Util.InverseScale(_SpriteRenderer.bounds.size, transform.lossyScale);
            Vector3 scale = Vector3Util.InverseScale(_size, baseSize);
            transform.localScale = scale;
        }

        // TODO (darren): expose this in editor to change spriteRenderer
        private void SetSize() {
            _size = _SpriteRenderer.bounds.size;
        }
    }
}
