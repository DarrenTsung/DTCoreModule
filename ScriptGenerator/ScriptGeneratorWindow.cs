using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public class ScriptGeneratorWindow : EditorWindow {
    // PRAGMA MARK - Static
    [MenuItem("Window/Script Generator Browser")]
    public static void Open() {
      EditorWindow.GetWindow<ScriptGeneratorWindow>(false, "Script Generator Browser", true);
    }

    private static GUIStyle _kOddGUIStyle = GUIStyleUtil.StyleWithBackgroundColor(ColorUtil.LerpWhiteBlack(0.10f));
    private static GUIStyle _kEvenGUIStyle = GUIStyleUtil.StyleWithBackgroundColor(ColorUtil.LerpWhiteBlack(0.15f));


    // PRAGMA MARK - Internal
    private Vector2 _scrollPosition;
    private ScriptGenerator[] _scriptGenerators;

    void OnGUI() {
      if (this._scriptGenerators == null) {
        Debug.LogError("Unexpected this._scriptGenerators is null!");
        return;
      }

      this._scrollPosition = EditorGUILayout.BeginScrollView(this._scrollPosition);
        int i = 0;
        foreach (ScriptGenerator scriptGenerator in this._scriptGenerators) {
          GUIStyle style = i % 2 == 0 ? _kEvenGUIStyle : _kOddGUIStyle;

          EditorGUILayout.BeginHorizontal(style, GUILayout.Height(40));
            EditorGUILayout.LabelField(scriptGenerator.name);
            if (GUILayout.Button("Run")) {
              scriptGenerator.Run();
            }
          EditorGUILayout.EndHorizontal();

          i++;
        }
      EditorGUILayout.EndScrollView();
    }

    void OnEnable() {
      List<ScriptGenerator> scriptGenerators = new List<ScriptGenerator>();

			string[] guids = AssetDatabase.FindAssets("t:ScriptGenerator");
      foreach (string guid in guids) {
        var scriptGenerator = AssetDatabase.LoadAssetAtPath<ScriptGenerator>(AssetDatabase.GUIDToAssetPath(guid));
        if (scriptGenerator == null) {
          continue;
        }

        scriptGenerators.Add(scriptGenerator);
      }

      this._scriptGenerators = scriptGenerators.ToArray();
    }

    void OnDisable() {
      this._scriptGenerators = null;
    }
  }
}