using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public class ScaleTween : Tween {
    // PRAGMA MARK - Internal
    [Header("Scale Properties")]
    [SerializeField] private AnimationCurve _xScaleCurve = AnimationCurveUtil.Default1To1();
    [SerializeField] private AnimationCurve _yScaleCurve = AnimationCurveUtil.Default1To1();
    [SerializeField] private AnimationCurve _zScaleCurve = AnimationCurveUtil.Default1To1();

    protected override void HandleValueUpdated(float value) {
      this.transform.localScale = new Vector3(this._xScaleCurve.Evaluate(value),
                                              this._yScaleCurve.Evaluate(value),
                                              this._zScaleCurve.Evaluate(value));
    }
  }
}
