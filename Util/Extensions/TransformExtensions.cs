using System.Collections;
using UnityEngine;

namespace DT {
  public static class TransformExtensions {
  	public static T GetComponentInParent<T>(this Transform transform, bool required = true) {
  		T found = transform.gameObject.GetComponentInParent<T>();
  		if (found == null && required) {
  			Debug.LogError("GetComponentInParent<T> - missing parent component!");
  		}
  		return found;
  	}
  }
}
