using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[CustomPropertyDrawer(typeof(DateTime))]
public class DateTimeDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // EditorGUI.BeginProperty(position, label, property);

        // Draw label
        // position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Draw string of the date
        // DateTime date = (DateTime)(object)property.objectReferenceValue;
        // EditorGUI.TextField(position, "this is a test: " + date.ToString("F"));
        // EditorGUI.TextField(position, "this is a test!");
        EditorGUI.Slider(new Rect(position.x, position.y, position.width - 40, position.height),
          0.5f, 0.0f, 1.0f);

        // EditorGUI.EndProperty();
    }
}