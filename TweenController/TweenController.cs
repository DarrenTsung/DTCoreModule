using DT;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public class TweenController : MonoBehaviour {
    // PRAGMA MARK - Public Interface
    public float Time {
      set {
        if (this._time == value) {
          return;
        }

        this._time = value;
        this.SynchronizeTweens();
      }
    }

    public void AddTween(Tween t) {
      if (this.Tweens.Contains(t)) {
        return;
      }

      this.Tweens.Add(t);
      t.Controller = this;
    }


    // PRAGMA MARK - Internal
    [SerializeField, Range(0.0f, 1.0f)] private float _time = 0.0f;

    [SerializeField, ReadOnly] private List<Tween> _tweens = null;
    private List<Tween> Tweens {
      get {
        if (this._tweens == null) {
          this._tweens = this.GetComponentsInChildren<Tween>().ToList();
          foreach (Tween t in this.Tweens) {
            t.Controller = this;
          }
        }
        return this._tweens;
      }
    }

    void OnValidate() {
      this.SynchronizeTweens();
    }

    private void SynchronizeTweens() {
      this._tweens = this.Tweens.Where(t => t != null).ToList();

      // synchronize time between all child tweens
      foreach (Tween t in this.Tweens) {
        t.Time = this._time;
      }
    }
  }
}
