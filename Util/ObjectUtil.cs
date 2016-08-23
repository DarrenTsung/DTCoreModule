using DT;
using System;
﻿using UnityEngine;

namespace DT {
	public static class ObjectUtil {
    public static T FindRequiredObjectOfType<T>() where T : UnityEngine.Object {
      T obj;
      obj = (T)UnityEngine.Object.FindObjectOfType(typeof(T));
      if (obj == null) {
        Debug.LogError("Failed to find required object of type: " + typeof(T).Name + "!");
      }
      return obj;
    }

    public static T FindFirstRequiredObjectOfType<T>(Predicate<T> predicate) where T : UnityEngine.Object {
      T[] objects = (T[])UnityEngine.Object.FindObjectsOfType(typeof(T));
      foreach (T obj in objects) {
        if (predicate.Invoke(obj)) {
          return obj;
        }
      }

      Debug.LogError("Failed to find required object of type: " + typeof(T).Name + "!");
      return default(T);
    }
	}
}