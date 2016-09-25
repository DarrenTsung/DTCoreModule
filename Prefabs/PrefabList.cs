using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class PrefabList {
		private static Dictionary<string, GameObject> _prefabMap = new Dictionary<string, GameObject>();

		static PrefabList() {
			GameObject[] loadedPrefabs = Resources.LoadAll<GameObject>("");
			foreach (GameObject g in loadedPrefabs) {
				PrefabList._prefabMap[g.name.ToLower()] = g;
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