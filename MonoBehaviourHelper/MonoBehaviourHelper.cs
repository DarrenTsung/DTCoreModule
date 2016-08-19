using DTOpenObjectWindow;
using System;
using UnityEngine;

namespace DT {
  [OpenableClass]
  public class MonoBehaviourHelper : Singleton<MonoBehaviourHelper> {
    [OpenableMethod]
    public static void MultitaskApplication() {
      if (!Application.isPlaying) {
        Debug.Log("Won't multitask because the application is not playing!");
        return;
      }

      MonoBehaviourHelper.Instance.OnApplicationPause(paused : true);
      CoroutineWrapper.DoAfterFrame(() => {
        MonoBehaviourHelper.Instance.OnApplicationPause(paused : false);
      });
    }

    public static event Action OnUpdate = delegate {};
    public static event Action OnFixedUpdate = delegate {};
    public static event Action OnApplicationPaused = delegate {};
    public static event Action OnApplicationResumed = delegate {};


    // PRAGMA MARK - Public Interface
    public void Initialize() {
      // empty function so singleton will be created
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
  }
}