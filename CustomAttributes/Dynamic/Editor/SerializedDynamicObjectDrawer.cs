using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DT {
  public class SerializedDynamicObjectDrawer<T> : PropertyDrawer where T : class {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      int oldIndex = this.GetCurrentIndex(property);
      int newIndex = EditorGUILayout.Popup(oldIndex, TypeUtil.GetImplementationTypeNames(typeof(T)));
      if (newIndex != oldIndex) {
        this.ChangeCurrentIndex(property, newIndex);
      }

      FieldInfo[] fields = TypeUtil.GetInspectorFields(this.GetCurrentImplementationType(property));
      foreach (FieldInfo field in fields) {
        EditorGUILayoutUtil.DynamicField(field, this.GetCurrentDynamicObject(property));
      }
      this.SaveCurrentDynamicObject(property);
    }



    // PRAGMA MARK - Internal
    private Dictionary<SerializedProperty, T> _cachedDynamicObjectMapping = new Dictionary<SerializedProperty, T>();

    private T GetCurrentDynamicObject(SerializedProperty property) {
      if (!this._cachedDynamicObjectMapping.ContainsKey(property)) {
        SerializedProperty p = property.FindPropertyRelative("serializedDynamicObject");
        if (p.stringValue.IsNullOrEmpty()) {
          this._cachedDynamicObjectMapping[property] = (T)Activator.CreateInstance(this.GetCurrentImplementationType(property));
          this.SaveCurrentDynamicObject(property);
        } else {
          this._cachedDynamicObjectMapping[property] = JsonSerialization.DeserializeGeneric<T>(p.stringValue);
        }
      }

      return this._cachedDynamicObjectMapping[property];
    }

    private void SaveCurrentDynamicObject(SerializedProperty property) {
      SerializedProperty p = property.FindPropertyRelative("serializedDynamicObject");
      p.stringValue = JsonSerialization.SerializeGeneric(this._cachedDynamicObjectMapping[property]);
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