using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DT {
  public class SerializedDynamicObjectDrawer<T> : PropertyDrawer where T : ScriptableObject {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      int oldIndex = this.GetCurrentIndex(property);
      int newIndex = EditorGUILayout.Popup(oldIndex, TypeUtil.GetImplementationTypeNames(typeof(T)));
      if (newIndex != oldIndex) {
        this.ChangeCurrentIndex(property, newIndex);
      }

      SerializedObject serializedObject = this.GetCurrentSerializedObject(property);
      serializedObject.Update();
      EditorGUI.BeginChangeCheck();

      SerializedProperty firstProperty = serializedObject.GetIterator();
      foreach (SerializedProperty p in firstProperty.Recurse()) {
        EditorGUILayout.PropertyField(p);
      }


      if (EditorGUI.EndChangeCheck()) {
        serializedObject.ApplyModifiedProperties();
        this.SaveCurrentDynamicObject(property);
      }
    }



    // PRAGMA MARK - Internal
    private Dictionary<SerializedProperty, T> _cachedDynamicObjectMapping = new Dictionary<SerializedProperty, T>();
    private Dictionary<SerializedProperty, SerializedObject> _cachedSerializedObjectMapping = new Dictionary<SerializedProperty, SerializedObject>();

    private T GetCurrentDynamicObject(SerializedProperty property) {
      if (!this._cachedDynamicObjectMapping.ContainsKey(property)) {
        SerializedProperty p = property.FindPropertyRelative("serializedDynamicObject");
        this._cachedDynamicObjectMapping[property] = (T)ScriptableObject.CreateInstance(this.GetCurrentImplementationType(property));
        if (!p.stringValue.IsNullOrEmpty()) {
          JsonUtility.FromJsonOverwrite(p.stringValue, this._cachedDynamicObjectMapping[property]);
        }
      }

      return this._cachedDynamicObjectMapping[property];
    }

    private SerializedObject GetCurrentSerializedObject(SerializedProperty property) {
      if (!this._cachedSerializedObjectMapping.ContainsKey(property)) {

        T obj = this.GetCurrentDynamicObject(property);
        this._cachedSerializedObjectMapping[property] = new SerializedObject(obj);
      }
      return this._cachedSerializedObjectMapping[property];
    }

    private void SaveCurrentDynamicObject(SerializedProperty property) {
      SerializedProperty p = property.FindPropertyRelative("serializedDynamicObject");
      p.stringValue = JsonUtility.ToJson(this._cachedDynamicObjectMapping[property]);
      this._cachedSerializedObjectMapping.Remove(property);
    }

    private void ClearCurrentDynamicObject(SerializedProperty property) {
      SerializedProperty p = property.FindPropertyRelative("serializedDynamicObject");
      p.stringValue = null;
      this._cachedDynamicObjectMapping.Remove(property);
    }

    private int GetCurrentIndex(SerializedProperty property) {
      SerializedProperty implementationTypeNameProperty = property.FindPropertyRelative("implementationTypeName");
      string[] implementationTypeNames = TypeUtil.GetImplementationTypeNames(typeof(T));

      int index = Array.IndexOf(implementationTypeNames, implementationTypeNameProperty.stringValue);
      if (index == -1) {
        index = 0;

        implementationTypeNameProperty.stringValue = implementationTypeNames[index];
        this.ClearCurrentDynamicObject(property);
      }

      return index;
    }

    private void ChangeCurrentIndex(SerializedProperty property, int newIndex) {
      SerializedProperty implementationTypeNameProperty = property.FindPropertyRelative("implementationTypeName");
      string[] implementationTypeNames = TypeUtil.GetImplementationTypeNames(typeof(T));

      implementationTypeNameProperty.stringValue = implementationTypeNames[newIndex];
      this.ClearCurrentDynamicObject(property);
    }

    private Type GetCurrentImplementationType(SerializedProperty property) {
      Type[] implementationTypes = TypeUtil.GetImplementationTypes(typeof(T));
      return implementationTypes[this.GetCurrentIndex(property)];
    }
  }
}