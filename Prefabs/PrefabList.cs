using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class PrefabList {
		private static Dictionary<string, GameObject> _prefabMap = new Dictionary<string, GameObject>();

		static PrefabList() {
			Object[] loadedPrefabs = Resources.LoadAll("", typeof(GameObject));
			foreach (Object o in loadedPrefabs) {
				GameObject g = o as GameObject;
				PrefabList._prefabMap[g.name.ToLower()] = g;
			}

      AssetBundle streamingAssets = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + ApplicationUtil.PlatformAssetBundleString() + "/bundled");
      if (streamingAssets == null) {
        Debug.LogError("Failed to load streaming assets");
        return;
      }

      GameObject[] prefabs = streamingAssets.LoadAllAssets<GameObject>();
			foreach (GameObject g in prefabs) {
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