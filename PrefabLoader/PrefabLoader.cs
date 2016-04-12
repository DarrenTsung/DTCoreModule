using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
	public class PrefabLoader : MonoBehaviour {
    public static void InstantiatePrefabOnObject(GameObject obj, string prefabName, Action<GameObject> callback) {
      if (string.IsNullOrEmpty(prefabName) || obj == null) {
        Debug.LogError("Failed call on SpawnPrefabOnObject: prefabName: " + prefabName + " empty or obj: " + obj + " is null!");
        callback(null);
        return;
      }

      GameObject newObject = ObjectPoolManager.Instantiate(prefabName, parent : obj);
      callback(newObject);
    }

		public static void InstantiatePrefab(string prefabName, Action<GameObject> callback) {
      if (string.IsNullOrEmpty(prefabName)) {
        Debug.LogError("Failed call on SpawnPrefab: prefabName: " + prefabName + " empty!");
        callback(null);
        return;
      }

      GameObject newObject = ObjectPoolManager.Instantiate(prefabName);
      callback(newObject);
		}
	}
}