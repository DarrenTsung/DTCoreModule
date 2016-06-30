using DT;
﻿using UnityEngine;

namespace DT {
	public static class ObjectUtil {
    public static T FindRequiredObjectOfType<T>() where T : Object {
      T obj;
      obj = (T)Object.FindObjectOfType(typeof(T));
      if (obj == null) {
        Debug.LogError("Failed to find required object of type: " + typeof(T).Name + "!");
      }
      return obj;
    }
	}
}