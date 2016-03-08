using System;
using System.Collections;
using UnityEngine;

namespace DT {
  public class CoroutineWrapper {
    // PRAGMA MARK - Static
    public static void Initialize() {
      CoroutineManager.Instance.Initialize();
    }

    public static CoroutineWrapper StartCoroutine(IEnumerator coroutine, Action finishedCallback) {
      return new CoroutineWrapper(coroutine, finishedCallback);
    }

    public static CoroutineWrapper StartCoroutine(IEnumerator coroutine, Action<bool> finishedCallback = null) {
      return new CoroutineWrapper(coroutine, finishedCallback);
    }

    public static CoroutineWrapper DoAfterDelay(float delay, Action finishedCallback) {
      return CoroutineWrapper.StartCoroutine(CoroutineWrapper.DelayCoroutine(delay), finishedCallback);
    }

    private static IEnumerator DelayCoroutine(float delay) {
      yield return new WaitForSeconds(delay);
    }


    // PRAGMA MARK - Public Interface
    public void Stop() {
      this._running = false;
      this._manuallyStopped = true;
    }


    // PRAGMA MARK - Internal
    private CoroutineWrapper(IEnumerator coroutine, Action finishedCallback) : this(coroutine) {
      this._finishedNoArgsCallback = finishedCallback;
    }

    private CoroutineWrapper(IEnumerator coroutine, Action<bool> finishedCallback) : this(coroutine) {
      this._finishedArgsCallback = finishedCallback;
    }

    private CoroutineWrapper(IEnumerator coroutine) {
      this._coroutine = coroutine;
      CoroutineManager.Instance.StartCoroutine(this.Coroutine());
    }

    private Action _finishedNoArgsCallback;
    private Action<bool> _finishedArgsCallback;
    private IEnumerator _coroutine;

    private bool _manuallyStopped = false;
    private bool _running = true;

    private IEnumerator Coroutine() {
      while (this._running) {
        if (this._coroutine != null && this._coroutine.MoveNext()) {
          yield return this._coroutine.Current;
        } else {
          this._running = false;
        }
      }

      if (this._finishedNoArgsCallback != null) {
        this._finishedNoArgsCallback.Invoke();
      }

      if (this._finishedArgsCallback != null) {
        this._finishedArgsCallback(this._manuallyStopped);
      }
    }

    private class CoroutineManager : Singleton<CoroutineManager> {
      public void Initialize() {
        // empty method so that the object is created
      }
    }
  }
}