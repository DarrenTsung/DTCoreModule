using DT;
using System;
using UnityEngine;

namespace DT {
	public static class PlayerPrefsUtil {
		public static void IncrementInt(string key, int defaultValue = 0) {
			int oldValue = PlayerPrefs.GetInt(key, defaultValue);
			PlayerPrefs.SetInt(key, oldValue + 1);
		}

		public static bool GetBool(string key) {
			return PlayerPrefs.GetInt(key) > 0;
		}

		public static void SetBool(string key, bool val) {
			PlayerPrefs.SetInt(key, val ? 1 : 0);
		}
	}
}