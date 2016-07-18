using DT;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public class TweenController : MonoBehaviour {
    // PRAGMA MARK - Public Interface
    public float Value {
      set {
        if (this._value == value) {
          return;
        }

        this._value = value;
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

    public void Play() {
      if (this._playCoroutine != null) {
        this.StopCoroutine(this._playCoroutine);
        this._playCoroutine = null;
      }

      this._playCoroutine = this.DoEveryFrameForDuration(this._duration, (float time, float duration) => {
        this.Value = time / duration;
      });
    }


    // PRAGMA MARK - Internal
    [SerializeField, Range(0.0f, 1.0f)] private float _value = 0.0f;

    [Header("Properties")]
    [SerializeField] private float _duration = 1.0f;

    [Header("Read-Only Properties")]
    [SerializeField, ReadOnly] private List<Tween> _tweens = null;

    private Coroutine _playCoroutine;

    private List<Tween> Tweens {
      get {
        if (this._tweens == null) {
          this._tweens = this.GetComponentsInChildren<Tween>().ToList();
          foreach (Tween t in this.Tweens) {
            if (t.Controller != null) {
              continue;
            }

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
        t.Value = this._value;
      }
    }
  }
}
