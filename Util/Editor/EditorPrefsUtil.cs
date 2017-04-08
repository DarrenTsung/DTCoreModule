using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace DT {
	public static class EditorPrefsUtil {
		public static bool GetBool(string key) {
			return EditorPrefs.GetInt(key) != 0;
		}

		public static void SetBool(string key, bool val) {
			EditorPrefs.SetInt(key, val ? 1 : 0);
		}
	}
}