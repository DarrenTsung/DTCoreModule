using System;
using System.Collections;
using UnityEngine;

namespace DT {
  [Serializable]
  public class FloatSpring : IDisposable {
    // PRAGMA MARK - Public Interface
    public float Value {
      get { return this._currentValue; }
    }

    public float TargetValue {
      get { return this._targetValue; }
    }

		/// <summary>
		/// uses the semi-implicit euler method. faster, but not always stable.
		/// see http://allenchou.net/2015/04/game-math-more-on-numeric-springing/
		/// </summary>
		/// <param name="dampingRatio">lower values are less damped and higher values are more damped resulting in less springiness.
		/// should be between 0.01f, 1f to avoid unstable systems.</param>
		/// <param name="angularFrequency">An angular frequency of 2pi (radians per second) means the oscillation completes one
		/// full period over one second, i.e. 1Hz. should be less than 35 or so to remain stable</param>
    public FloatSpring(float startingValue, float dampingRatio, float angularFrequency) {
      this._currentValue = startingValue;
      this._targetValue = startingValue;

      this._dampingRatio = dampingRatio;
      this._angularFrequency = angularFrequency;

      MonoBehaviourHelper.OnUpdate += this.HandleUpdate;
    }

    public void SetTargetValue(float targetValue) {
      this._targetValue = targetValue;
      this._velocity = 0.0f;
    }

    public void ResetValues(float currentValue) {
      this._currentValue = currentValue;
      this._velocity = 0.0f;
    }


    // PRAGMA MARK - IDisposable Implementation
    public void Dispose() {
      MonoBehaviourHelper.OnUpdate -= this.HandleUpdate;
    }


    // PRAGMA MARK - Internal
    [SerializeField] private float _dampingRatio;
    [SerializeField] private float _angularFrequency;

    [SerializeField, ReadOnly] private float _currentValue;
    [SerializeField, ReadOnly] private float _targetValue;

    [SerializeField, ReadOnly] private float _velocity;

    private void HandleUpdate() {
      this._velocity += (-2.0f * Time.deltaTime * this._dampingRatio * this._angularFrequency * this._velocity) + (Time.deltaTime * this._angularFrequency * this._angularFrequency * (this._targetValue - this._currentValue));
      this._currentValue += Time.deltaTime * this._velocity;
    }
  }

  public static class FloatSpringExtensions {
    public static void SetTargetValueIfDifferent(this FloatSpring spring, float targetValue) {
      if (spring.TargetValue == targetValue) {
        return;
      }

      spring.SetTargetValue(targetValue);
    }
  }
}