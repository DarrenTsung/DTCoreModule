using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class GameObjectExtensions {
    public static string FullName(this GameObject g) {
      string name = g.name;
      while (g.transform.parent != null) {
        g = g.transform.parent.gameObject;
        name = g.name + "/" + name;
      }
      return name;
    }
    
    public static bool IsInLayerMask(this GameObject g, LayerMask mask) {
      return ((mask.value & (1 << g.layer)) > 0);
    }
    
    public static T GetCachedComponent<T>(this GameObject g, Dictionary<Type, MonoBehaviour> cache) where T : class {
			Type type = typeof(T);
      
			if (!cache.ContainsKey(type)) {
				MonoBehaviour component = g.GetComponent<T>() as MonoBehaviour;
				
				if (!component) {
					Debug.LogError("Failed to get component for type: " + type);
					return default(T);
				}
				
				cache[type] = component;
			}
			
			return cache[type] as T;
    }
  }
}
