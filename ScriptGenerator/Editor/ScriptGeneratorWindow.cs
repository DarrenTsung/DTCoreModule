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


    // PRAGMA MARK - Internal
    private Vector2 _scrollPosition;
    private ScriptGenerator[] _scriptGenerators;

    void OnGUI() {
      if (this._scriptGenerators == null) {
        Debug.LogError("Unexpected this._scriptGenerators is null!");
        return;
      }

      EditorGUILayout.BeginHorizontal(GUILayout.Height(20));
        ScriptGenerator.Log = EditorGUILayout.Toggle("Log Information", ScriptGenerator.Log);
      EditorGUILayout.EndHorizontal();

      this._scrollPosition = EditorGUILayout.BeginScrollView(this._scrollPosition);
        int i = 0;
        foreach (ScriptGenerator scriptGenerator in this._scriptGenerators) {
          GUIStyle style = EditorGUIStyleUtil.CachedStyleWithColorFor(i);

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