using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
	public static class EmbeddedScriptableObjectGUI {
		// PRAGMA MARK - Public Interface
		public static void IncreaseIndent() {
			indentLevel_++;
			if (indentLevel_ <= 0) {
				return;
			}

			EditorGUILayout.BeginVertical(indentLevel_ % 2 == 0 ? EvenGuistyle_ : OddGuistyle_);
		}

		public static void DecreaseIndent() {
			indentLevel_--;
			if (indentLevel_ < 0) {
				return;
			}

			EditorGUILayout.EndVertical();
		}


		// PRAGMA MARK - Internal
		private const int kOffset = 15;

		private static int indentLevel_ = 0;

		private static GUIStyle oddGuistyle_;
		private static GUIStyle OddGuistyle_ {
			get {
				if (oddGuistyle_ == null) {
					oddGuistyle_ = EditorGUIStyleUtil.StyleWithOddColor();
					oddGuistyle_.padding.left = kOffset;
					oddGuistyle_.margin.left = kOffset;
				}

				return oddGuistyle_;
			}
		}

		private static GUIStyle evenGuistyle_;
		private static GUIStyle EvenGuistyle_ {
			get {
				if (evenGuistyle_ == null) {
					evenGuistyle_ = EditorGUIStyleUtil.StyleWithEvenColor();
					evenGuistyle_.padding.left = kOffset;
					evenGuistyle_.margin.left = kOffset;
				}

				return evenGuistyle_;
			}
		}
	}
}