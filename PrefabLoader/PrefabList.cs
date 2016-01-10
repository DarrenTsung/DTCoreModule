using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DT {
	public static class PrefabList {
		private static Dictionary<string, GameObject> _prefabMap;
    
		static PrefabList() {
			PrefabList._prefabMap = new Dictionary<string, GameObject>();

			Object[] loadedPrefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
			foreach (Object o in loadedPrefabs) {
				GameObject go = o as GameObject;
				PrefabList._prefabMap.Add(go.name, go);
			}
		}

		public static bool IsValidPrefabName(string name) {
			return PrefabList._prefabMap.ContainsKey(name);
		}

		public static GameObject PrefabForName(string name) {
      if (!PrefabList.IsValidPrefabName(name)) {
        Debug.LogError("PrefabForName: invalid prefab name: (" + name + "), not in list!");
        return null;
      }
      
			return PrefabList._prefabMap[name];
		}
	}
}