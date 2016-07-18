using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public class AnchoredPositionTween : Tween {
    // PRAGMA MARK - Internal
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;

    private RectTransform _rectTransform;
    private RectTransform RectTransform {
      get {
        if (this._rectTransform == null) {
          this._rectTransform = this.GetRequiredComponent<RectTransform>();
        }

        return this._rectTransform;
      }
    }

    protected override void HandleValueUpdated(float value) {
      this.RectTransform.anchoredPosition = Vector2.Lerp(this._startPosition, this._endPosition, value);
    }
  }
}
