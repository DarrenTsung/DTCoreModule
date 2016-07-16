using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public class PositionTween : Tween {
    // PRAGMA MARK - Internal
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;

    protected override void HandleTimeUpdated(float time) {
      this.transform.position = Vector3.Lerp(this._startPosition, this._endPosition, time);
    }
  }
}
