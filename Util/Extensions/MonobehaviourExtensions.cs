using System.Collections;
using UnityEngine;

namespace DT {
  public static class MonoBehaviourExtensions {
    public static T GetRequiredComponent<T>(this MonoBehaviour g) {
      T component = g.GetComponent<T>();
      if (component == null) {
        Debug.Log("Component " + typeof(T).Name + " missing in " + g.gameObject.FullName());
      }
      return component;
    }
  }
}
