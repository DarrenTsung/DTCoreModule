using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class MonoBehaviourExtensions {
    public static T GetRequiredComponent<T>(this MonoBehaviour m) {
      T component = m.GetComponent<T>();
      if (component == null) {
        Debug.Log("Component " + typeof(T).Name + " missing in " + m.gameObject.FullName());
      }
      return component;
    }
    
    public static void SetSelfAsParent(this MonoBehaviour m, GameObject other) {
      other.transform.parent = m.transform;
    }
    
    public static T GetCachedComponent<T>(this MonoBehaviour m, Dictionary<Type, MonoBehaviour> cache) where T : class {
      return m.gameObject.GetCachedComponent<T>(cache);
    }
  }
}
