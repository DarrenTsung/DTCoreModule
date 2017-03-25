using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
  [CustomEditor(typeof(ScriptableObject), true)]
  public class ScriptableObjectEditor : Editor {
    // PRAGMA MARK - Public Interface
    public override void OnInspectorGUI() {
      var scriptableObject = (ScriptableObject)this.target;

      string newName = EditorGUILayout.DelayedTextField("Asset Name", scriptableObject.name);
      if (newName != scriptableObject.name) {
        var assetPath = AssetDatabase.GetAssetPath(scriptableObject);
        var fileName = Path.GetFileName(assetPath);
        var newFileName = fileName.Replace(scriptableObject.name, newName);
        AssetDatabase.RenameAsset(assetPath, assetPath.Replace(fileName, newFileName));

        scriptableObject.name = newName;

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
      }

      this.serializedObject.Update();
      Editor.DrawPropertiesExcluding(this.serializedObject, _kScriptPropertyName);
      this.serializedObject.ApplyModifiedProperties();
    }


    // PRAGMA MARK - Internal
    private static readonly string[] _kScriptPropertyName = new string[] { "m_Script" };
  }
}