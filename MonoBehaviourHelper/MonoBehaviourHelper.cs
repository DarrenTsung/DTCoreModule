using System;
using UnityEngine;

namespace DT {
  public class MonoBehaviourHelper : Singleton<MonoBehaviourHelper> {
    static MonoBehaviourHelper() {
      MonoBehaviourHelper.Instance.Initialize();
    }

    public static event Action OnUpdate = delegate {};


    // PRAGMA MARK - Public Interface
    public void Initialize() {
      // empty function so singleton will be created
    }

    public void Update() {
      MonoBehaviourHelper.OnUpdate.Invoke();
    }
  }
}