using System;
using System.Collections;
using UnityEngine;

namespace DT {
	/// <summary>
	/// uses the semi-implicit euler method. faster, but not always stable.
	/// see http://allenchou.net/2015/04/game-math-more-on-numeric-springing/
	/// </summary>
  public class FloatSpring : MonoBehaviour {
    // PRAGMA MARK - Public Interface
    public float Value {
      get { return this._currentValue; }
    }

    public float TargetValue {
      get { return this._targetValue; }
    }

    public void SetTargetValue(float targetValue) {
      this._targetValue = targetValue;
      this._velocity = 0.0f;
    }

    public void ResetValues(float val) {
      this._currentValue = val;
      this._targetValue = val;
      this._velocity = 0.0f;
    }


    // PRAGMA MARK - Internal
    [Header("Properties")]
		// lower values are less damped and higher values are more damped resulting in less springiness.
		// should be between 0.01f, 1f to avoid unstable systems.
    [SerializeField, Range(0.01f, 1.0f)] private float _dampingRatio;
		// An angular frequency of 2pi (radians per second) means the oscillation completes one
		// full period over one second, i.e. 1Hz. should be less than 35 or so to remain stable
    [SerializeField] private float _angularFrequency;

    [Header("Read-Only")]
    [SerializeField, ReadOnly] private float _currentValue = 0.0f;
    [SerializeField, ReadOnly] private float _targetValue = 0.0f;

    [SerializeField, ReadOnly] private float _velocity = 0.0f;

    void Update() {
      this._velocity += (-2.0f * Time.deltaTime * this._dampingRatio * this._angularFrequency * this._velocity) + (Time.deltaTime * this._angularFrequency * this._angularFrequency * (this._targetValue - this._currentValue));
      this._currentValue += Time.deltaTime * this._velocity;
    }
  }

  public static class FloatSpringExtensions {
    public static bool SetTargetValueIfDifferent(this FloatSpring spring, float targetValue) {
      if (spring.TargetValue == targetValue) {
        return false;
      }

      spring.SetTargetValue(targetValue);
      return true;
    }
  }
}