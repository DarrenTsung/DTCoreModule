using DT;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace DT {
	public static class EditorGUIUtil {
		private static MethodInfo boldFontMethodInfo_ = null;

		public static void SetBoldDefaultFont(bool value) {
			if (boldFontMethodInfo_ == null) {
				boldFontMethodInfo_ = typeof(EditorGUIUtility).GetMethod("SetBoldDefaultFont", BindingFlags.Static | BindingFlags.NonPublic);
			}
			boldFontMethodInfo_.Invoke(null, new[] { value as object });
		}
	}
}
#endif