using DT;
using System;
using System.Reflection;
﻿using UnityEngine;

namespace DT {
	public static class ObjectUtil {
    public static void DestroyImmediateRecursive(UnityEngine.Object obj, bool allowDestroyingAssets = false) {
      if (obj == null) {
        return;
      }

      Type objType = obj.GetType();
      foreach (FieldInfo f in TypeUtil.GetInspectorFields(objType)) {
        foreach (UnityEngine.Object o in f.GetUnityEngineObjects(obj)) {
          ObjectUtil.DestroyImmediateRecursive(o, allowDestroyingAssets);
        }
      }

      UnityEngine.Object.DestroyImmediate(obj, allowDestroyingAssets);
    }

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