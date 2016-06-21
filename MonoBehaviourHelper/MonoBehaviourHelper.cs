using System;
using UnityEngine;

namespace DT {
  [OpenableClass]
  public class MonoBehaviourHelper : Singleton<MonoBehaviourHelper> {
    static MonoBehaviourHelper() {
      if (!Application.isPlaying) {
        return;
      }

      MonoBehaviourHelper.Instance.Initialize();
    }

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
    public static event Action OnApplicationPaused = delegate {};
    public static event Action OnApplicationResumed = delegate {};


    // PRAGMA MARK - Public Interface
    public void Initialize() {
      // empty function so singleton will be created
    }

    public void Update() {
      MonoBehaviourHelper.OnUpdate.Invoke();
    }

    public void OnApplicationPause(bool paused) {
      if (paused) {
        MonoBehaviourHelper.OnApplicationPaused.Invoke();
      } else {
        MonoBehaviourHelper.OnApplicationResumed.Invoke();
      }
    }
  }
}