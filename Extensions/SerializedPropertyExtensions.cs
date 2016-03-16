using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace DT {
  public static class SeralizedPropertyExtensions {
    public static object GetValueAsObject(this SerializedProperty property) {
      switch (property.propertyType) {
        case SerializedPropertyType.Integer:
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
        default:
          return (object)property.objectReferenceValue;
      }
    }
  }
}
#endif
