using System.Collections;
using UnityEditor;
using UnityEngine;

namespace DT {
  public static class EditorGUILayoutExtensions {
    public static void Header(string headerString) {
			EditorGUILayout.Space();
			EditorGUILayout.LabelField(headerString, EditorStyles.boldLabel);
    }
  }
}
