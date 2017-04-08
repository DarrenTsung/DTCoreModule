using System.Collections;
using UnityEngine;

namespace DT {
	public static class EditorGUIStyleUtil {
		// PRAGMA MARK - Public Interface
		public static GUIStyle StyleWithOddColor() {
			return GUIStyleUtil.StyleWithBackgroundColor(EditorColorUtil.OddColor());
		}

		public static GUIStyle StyleWithEvenColor() {
			return GUIStyleUtil.StyleWithBackgroundColor(EditorColorUtil.EvenColor());
		}

		public static GUIStyle CachedStyleWithOddColor() {
			return oddGuistyle_ ?? (oddGuistyle_ = StyleWithOddColor());
		}

		public static GUIStyle CachedStyleWithEvenColor() {
			return evenGuistyle_ ?? (evenGuistyle_ = StyleWithEvenColor());
		}

		public static GUIStyle CachedStyleWithColorFor(int index) {
			return index % 2 == 0 ? CachedStyleWithEvenColor() : CachedStyleWithOddColor();
		}


		// PRAGMA MARK - Internal
		private static GUIStyle oddGuistyle_ = null;
		private static GUIStyle evenGuistyle_ = null;
	}
}
