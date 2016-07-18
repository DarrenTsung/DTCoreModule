using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  [ExecuteInEditMode]
  public abstract class Tween : MonoBehaviour {
    // PRAGMA MARK - Public Interface
    public float Value {
      set {
        if (this._value == value) {
          return;
        }

        this._value = value;
        this.HandleValueUpdated(this._value);
      }
    }

    public TweenController Controller {
      get { return this._controller; }
      set { this._controller = value; }
    }


    // PRAGMA MARK - Internal
    [SerializeField, Range(0.0f, 1.0f)] private float _value = 0.0f;

    [Header("Outlets")]
    [SerializeField] private TweenController _controller;

    void OnEnable() {
      TweenController tc = this.GetComponentInParent<TweenController>();
      if (tc != null) {
        tc.AddTween(this);
      }
    }

    void OnValidate() {
      if (this.Controller != null) {
        this.Controller.Value = this._value;
      }
      this.HandleValueUpdated(this._value);
    }

    protected abstract void HandleValueUpdated(float time);
  }
}
