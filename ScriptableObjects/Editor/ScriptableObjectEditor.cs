using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
  [CustomEditor(typeof(ScriptableObject), true)]
  public class ScriptableObjectEditor : Editor {
    // PRAGMA MARK - Public Interface
    public override void OnInspectorGUI() {
      var scriptableObject = (ScriptableObject)this.target;

      EmbeddedScriptableObjectGUI.DecreaseIndent();
      string newName = EditorGUILayout.DelayedTextField("Asset Name", scriptableObject.name);
      if (newName != scriptableObject.name) {
        scriptableObject.name = newName;

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
      }
      EmbeddedScriptableObjectGUI.IncreaseIndent();

      this.serializedObject.Update();
      this.DrawPropertiesExcluding(this.serializedObject, _kScriptPropertyName);
      this.serializedObject.ApplyModifiedProperties();
    }


    // PRAGMA MARK - Internal
    private static readonly string[] _kScriptPropertyName = new string[] { "m_Script" };
  }
}