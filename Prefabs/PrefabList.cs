using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class PrefabList {
		private static Dictionary<string, GameObject> _prefabMap = new Dictionary<string, GameObject>();

		static PrefabList() {
			Object[] loadedPrefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
			foreach (Object o in loadedPrefabs) {
				GameObject go = o as GameObject;
				PrefabList._prefabMap[go.name.ToLower()] = go;
			}
		}

		public static GameObject PrefabForName(string name) {
      string lowercaseName = name.ToLower();

      if (!PrefabList._prefabMap.ContainsKey(lowercaseName)) {
        Debug.LogError("PrefabForName: invalid prefab name: (" + name + "), not in list!");
        return null;
      }

			return PrefabList._prefabMap[lowercaseName];
		}
	}
}