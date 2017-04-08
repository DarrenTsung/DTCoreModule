using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DT {
	public struct UnityConsoleCountsByType {
		public int errorCount;
		public int warningCount;
		public int logCount;
	}

	public static class UnityEditorConsoleUtil {
		private static MethodInfo clearMethod_;
		private static MethodInfo getCountMethod_;
		private static MethodInfo getCountsByTypeMethod_;

		static UnityEditorConsoleUtil() {
			Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
			Type logEntriesType = assembly.GetType("UnityEditorInternal.LogEntries");

			clearMethod_ = logEntriesType.GetMethod("Clear");
			getCountMethod_ = logEntriesType.GetMethod("GetCount");
			getCountsByTypeMethod_ = logEntriesType.GetMethod("GetCountsByType");
		}

		public static void Clear() {
			if (clearMethod_ == null) {
				Debug.LogError("Failed to find LogEntries.Clear method info!");
				return;
			}

			clearMethod_.Invoke(null, null);
		}

		public static int GetCount() {
			if (getCountMethod_ == null) {
				Debug.LogError("Failed to find LogEntries.GetCount method info!");
				return 0;
			}

			return (int)getCountMethod_.Invoke(null, null);
		}

		public static UnityConsoleCountsByType GetCountsByType() {
			UnityConsoleCountsByType countsByType = new UnityConsoleCountsByType();

			if (getCountsByTypeMethod_ == null) {
				Debug.LogError("Failed to find LogEntries.GetCountsByType method info!");
				return countsByType;
			}

			object[] arguments = new object[] { 0, 0, 0 };
			getCountsByTypeMethod_.Invoke(null, arguments);

			countsByType.errorCount = (int)arguments[0];
			countsByType.warningCount = (int)arguments[1];
			countsByType.logCount = (int)arguments[2];

			return countsByType;
		}
	}
}