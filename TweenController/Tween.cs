using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  [ExecuteInEditMode]
  public abstract class Tween : MonoBehaviour {
    // PRAGMA MARK - Public Interface
    public float Time {
      set {
        if (this._time == value) {
          return;
        }

        this._time = value;
        this.HandleTimeUpdated(this._time);
      }
    }

    public TweenController Controller {
      get; set;
    }


    // PRAGMA MARK - Internal
    [SerializeField, Range(0.0f, 1.0f)] private float _time = 0.0f;

    void OnEnable() {
      TweenController tc = this.GetComponentInParent<TweenController>();
      if (tc != null) {
        tc.AddTween(this);
      }
    }

    void OnValidate() {
      if (this.Controller != null) {
        this.Controller.Time = this._time;
      }
      this.HandleTimeUpdated(this._time);
    }

    protected abstract void HandleTimeUpdated(float time);
  }
}
