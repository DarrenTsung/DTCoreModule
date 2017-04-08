using DT;
using System;
using UnityEngine;

namespace DT {
	public static class GameObjectUtil {
		public static GameObject FindRequired(string name) {
			GameObject obj = GameObject.Find(name);
			if (obj == null) {
				Debug.LogError("Failed to find required GameObject named: " + name);
			}
			return obj;
		}
	}
}