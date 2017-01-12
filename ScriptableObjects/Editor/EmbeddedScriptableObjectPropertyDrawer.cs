using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
  [CustomPropertyDrawer(typeof(EmbeddedScriptableObject), true)]
  public class EmbeddedScriptableObjectPropertyDrawer : PropertyDrawer {
    // PRAGMA MARK - Public Interface
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      Editor.CreateCachedEditor(property.objectReferenceValue, null, ref this._editor);

      this._property = property;

      Color oldColor = GUI.color;
      GUI.color = Color.Lerp(Color.white, Color.yellow, 0.25f);

      EditorGUI.PropertyField(position, property, label);

      GUI.color = oldColor;

      if (this._editor != null) {
        EmbeddedScriptableObjectGUI.IncreaseIndent();

        this._editor.OnInspectorGUI();

        EmbeddedScriptableObjectGUI.DecreaseIndent();
      }

      // handle click on property
      Event clickEvent = Event.current;

      bool rightClick = clickEvent.type == EventType.MouseDown && clickEvent.button == 1;
      bool insidePosition = position.Contains(clickEvent.mousePosition);

      if (rightClick && insidePosition) {
        clickEvent.Use();

        EditorUtility.DisplayCustomMenu(new Rect(clickEvent.mousePosition, Vector2.zero),
          this._FieldImplementationTypes.Select(t => new GUIContent(t.Name)).ToArray(),
          selected: -1,
          callback: this.HandleCreateAssetClick,
          userData: null);
      }
    }


    // PRAGMA MARK - Internal
    private Editor _editor;
    private SerializedProperty _property;

    private Type[] _fieldImplementationTypes = null;
    private Type[] _FieldImplementationTypes {
      get {
        if (this._fieldImplementationTypes == null) {
          Type type = this.fieldInfo.FieldType;
          if (type.IsGenericType) {
            type = type.GetGenericArguments()[0];
          }

          this._fieldImplementationTypes = TypeUtil.GetImplementationTypes(type);
        }

        return this._fieldImplementationTypes;
      }
    }

    private void HandleCreateAssetClick(object userData, string[] options, int selected) {
      this.CreateAsset(this._FieldImplementationTypes[selected]);
    }

    private void CreateAsset(Type type) {
      UnityEngine.Object oldObject = this._property.objectReferenceValue;
      UnityEngine.Object assetClickedOn = Selection.activeObject;

      var asset = ScriptableObject.CreateInstance(type);
      asset.name = type.Name;

      if (oldObject != null) {
        if (!EditorUtility.DisplayDialog("Overwrite?", "This will overwrite the object previously in the field. This cannot be undone.", "Continue", "Cancel")) {
          return;
        }

        ObjectUtil.DestroyImmediateRecursive(oldObject, allowDestroyingAssets: true);
      }

      AssetDatabase.AddObjectToAsset(asset, assetClickedOn);
      AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(asset));
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();

      Selection.activeObject = asset;

      this._property.objectReferenceValue = asset;
      this._property.serializedObject.ApplyModifiedProperties();
    }
  }
}