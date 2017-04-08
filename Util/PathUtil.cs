using DT;
using System;
using UnityEngine;

namespace DT {
	public static class PathUtil {
		public const string kSceneExtension = ".unity";
		public const string kPrefabExtension = ".prefab";

		public static bool IsScene(string pathString) {
			return pathString.Contains(kSceneExtension);
		}

		public static bool IsPrefab(string pathString) {
			return pathString.Contains(kPrefabExtension);
		}
	}
}