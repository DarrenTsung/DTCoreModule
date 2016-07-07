using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DT {
  public static class SeralizedPropertyExtensions {
    public static void ExpandAllChildren(this SerializedProperty property) {
      property.SetIsExpandedForChildren(true);
    }

    public static void CollapseAllChildren(this SerializedProperty property) {
      property.SetIsExpandedForChildren(false);
    }

    private static void SetIsExpandedForChildren(this SerializedProperty property, bool isExpanded) {
      foreach (SerializedProperty p in property.Recurse()) {
        p.isExpanded = isExpanded;
      }
    }

    public static IEnumerable<SerializedProperty> Recurse(this SerializedProperty property, bool checkEndProperty = false) {
      property = property.Copy();

      SerializedProperty endProperty = null;
      if (checkEndProperty) {
        endProperty = property.GetEndProperty();
      }

      bool successful = property.NextVisible(enterChildren: true);
      if (!successful) {
        yield break;
      }

      do {
        yield return property;

        if (property.hasVisibleChildren) {
          EditorGUI.indentLevel++;

          foreach (SerializedProperty p in property.Recurse(checkEndProperty: true)) {
            yield return p;
          }

          EditorGUI.indentLevel--;
        }
      } while (property.NextVisible(enterChildren: false) && !SerializedProperty.EqualContents(property, endProperty));
    }

    public static object GetValueAsObject(this SerializedProperty property) {
      switch (property.propertyType) {
        case SerializedPropertyType.Integer:
        case SerializedPropertyType.ArraySize:
          return (object)property.intValue;
        case SerializedPropertyType.Float:
          return (object)property.floatValue;
        case SerializedPropertyType.Boolean:
          return (object)property.boolValue;
        case SerializedPropertyType.String:
          return (object)property.stringValue;
        case SerializedPropertyType.Vector2:
          return (object)property.vector2Value;
        case SerializedPropertyType.Vector3:
          return (object)property.vector3Value;
        case SerializedPropertyType.Vector4:
          return (object)property.vector4Value;
        case SerializedPropertyType.Rect:
          return (object)property.rectValue;
        case SerializedPropertyType.Quaternion:
          return (object)property.quaternionValue;
        case SerializedPropertyType.Color:
          return (object)property.colorValue;
        case SerializedPropertyType.Bounds:
          return (object)property.boundsValue;
        case SerializedPropertyType.ObjectReference:
          return (object)property.objectReferenceValue;
        default:
          throw new NotImplementedException("GetValueAsObject - Failed to parse SerializedPropertyType");
      }
    }
  }
}
