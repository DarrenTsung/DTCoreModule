using DTOpenObjectWindow;
using System;
using UnityEngine;

namespace DT {
  [OpenableClass]
  public static class MonoBehaviourHelper {
    public static event Action OnUpdate = delegate {};
    public static event Action OnFixedUpdate = delegate {};
    public static event Action OnApplicationPaused = delegate {};
    public static event Action OnApplicationResumed = delegate {};
    public static event Action OnApplicationQuit = delegate {};

    [OpenableMethod]
    public static void MultitaskApplication() {
      if (!Application.isPlaying) {
        Debug.Log("Won't multitask because the application is not playing!");
        return;
      }

      UnityHelper.Instance.MultitaskApplication();
    }

    static MonoBehaviourHelper() {
      UnityHelper.Instance.Initialize();
    }

    private class UnityHelper : Singleton<UnityHelper> {
      // PRAGMA MARK - Public Interface
      public void MultitaskApplication() {
        this.OnApplicationPause(paused : true);
        CoroutineWrapper.DoAfterFrame(() => {
          this.OnApplicationPause(paused : false);
        });
      }

      public void Initialize() {
        // empty function so that MonoBehaviour will be created
      }

      void Update() {
        MonoBehaviourHelper.OnUpdate.Invoke();
      }

      void FixedUpdate() {
        MonoBehaviourHelper.OnFixedUpdate.Invoke();
      }

      void OnApplicationPause(bool paused) {
        if (paused) {
          MonoBehaviourHelper.OnApplicationPaused.Invoke();
        } else {
          MonoBehaviourHelper.OnApplicationResumed.Invoke();
        }
      }

      void OnApplicationQuit() {
        MonoBehaviourHelper.OnApplicationQuit.Invoke();
      }
    }
  }
}