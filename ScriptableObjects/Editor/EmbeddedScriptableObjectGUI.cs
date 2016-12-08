using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
  public static class EmbeddedScriptableObjectGUI {
    // PRAGMA MARK - Public Interface
    public static void IncreaseIndent() {
      EmbeddedScriptableObjectGUI._indentLevel++;
      if (EmbeddedScriptableObjectGUI._indentLevel <= 0) {
        return;
      }

      EditorGUILayout.BeginVertical(_indentLevel % 2 == 0 ? _EvenGUIStyle : _OddGUIStyle);
    }

    public static void DecreaseIndent() {
      EmbeddedScriptableObjectGUI._indentLevel--;
      if (EmbeddedScriptableObjectGUI._indentLevel < 0) {
        return;
      }

      EditorGUILayout.EndVertical();
    }


    // PRAGMA MARK - Internal
    private const int _kOffset = 15;

    private static int _indentLevel = 0;

    private static GUIStyle _oddGUIStyle;
    private static GUIStyle _OddGUIStyle {
      get {
        if (_oddGUIStyle == null) {
          _oddGUIStyle = EditorGUIStyleUtil.StyleWithOddColor();
          _oddGUIStyle.padding.left = _kOffset;
          _oddGUIStyle.margin.left = _kOffset;
        }

        return _oddGUIStyle;
      }
    }

    private static GUIStyle _evenGUIStyle;
    private static GUIStyle _EvenGUIStyle {
      get {
        if (_evenGUIStyle == null) {
          _evenGUIStyle = EditorGUIStyleUtil.StyleWithEvenColor();
          _evenGUIStyle.padding.left = _kOffset;
          _evenGUIStyle.margin.left = _kOffset;
        }

        return _evenGUIStyle;
      }
    }
  }
}