using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class MonoBehaviourExtensions {
    public static T GetRequiredComponent<T>(this MonoBehaviour m) {
      return m.gameObject.GetRequiredComponent<T>();
    }
    
    public static void SetSelfAsParent(this MonoBehaviour m, GameObject other) {
      other.transform.parent = m.transform;
    }
    
    public static T GetCachedComponent<T>(this MonoBehaviour m, Dictionary<Type, MonoBehaviour> cache) where T : class {
      return m.gameObject.GetCachedComponent<T>(cache);
    }
    
    public static T GetRequiredComponentInChildren<T>(this MonoBehaviour m) {
      return m.gameObject.GetRequiredComponentInChildren<T>();
    }
    
    public static T GetOnlyComponentInChildren<T>(this MonoBehaviour m) {
      return m.gameObject.GetOnlyComponentInChildren<T>();
    }
    
    public static T GetRequiredComponentInParent<T>(this MonoBehaviour m) {
      return m.gameObject.GetRequiredComponentInParent<T>();
    }
    
    public static Coroutine DoAfterDelay(this MonoBehaviour m, float delay, Action callback) {
      if (delay < 0) {
        delay = 0;
      }
      return m.StartCoroutine(m.DoActionAfterDelayCoroutine(delay, callback));
    }
    
    public static IEnumerator DoActionAfterDelayCoroutine(this MonoBehaviour m, float delay, Action callback) {
      yield return new WaitForSeconds(delay);
      callback();
    }
    
    public static GameObject[] FindChildGameObjectsWithTag(this MonoBehaviour m, string tag) {
      return m.gameObject.FindChildGameObjectsWithTag(tag);
    }
  }
}
