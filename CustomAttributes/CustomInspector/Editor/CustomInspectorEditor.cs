#if UNITY_EDITOR
using DT;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using UnityEngine;
using UnityEditor;

// when implementing this in your MonoBehaviours, wrap your using UnityEditor and
// OnInspectorGUI/OnSceneGUI methods in #if UNITY_EDITOR/#endif

namespace DT {
  /// <summary>
  /// for fields to work with the Vector inspector they must either be public or marked with SerializeField and have the VectorInspectable
  /// attribute.
  /// </summary>
  [CustomEditor(typeof(UnityEngine.Object), true)]
  [CanEditMultipleObjects]
  public class CustomInspectorEditor : Editor {
    private MethodInfo _onInspectorGuiMethod;
    private MethodInfo _onSceneGuiMethod;
    private MethodInfo _onValidateMethod;
    private MethodInfo _updateMethod;
    private InspectorMethodButtonData[] _inspectorMethodButtonData = new InspectorMethodButtonData[0];

    // Vector editor
    private bool _hasVectorFields = false;
    private IEnumerable<FieldInfo> _vectorInspectibleFields;

    // Local Vector editor
    private bool _hasLocalVectorFields = false;
    private IEnumerable<FieldInfo> _localVectorInspectibleFields;

    private GUIStyle _methodGroupStyle;
    private GUIStyle MethodGroupStyle {
      get {
        if (this._methodGroupStyle == null) {
          this._methodGroupStyle = new GUIStyle();
          this._methodGroupStyle.normal.background = Texture2DUtil.CreateTextureWithColor(ColorUtil.HexStringToColor("#a9a9a9"));
        }
        return this._methodGroupStyle;
      }
    }



    public void OnEnable() {
      Type type = target.GetType();

      bool earlyExit = true;
      if (type.GetCustomAttributes(typeof(CustomInspectorAttribute), true).Count() > 0) {
        earlyExit = false;
      }

      if (earlyExit) {
        return;
      }

      this._onInspectorGuiMethod = type.GetMethod("OnInspectorGUI", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
      this._onSceneGuiMethod = type.GetMethod("OnSceneGUI", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
      if (type.IsDefined(typeof(ExecuteInEditMode), false)) {
        this._onValidateMethod = type.GetMethod("OnValidate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
        this._updateMethod = target.GetType().GetMethod("Update", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
      }

      var methodInfos = type.GetMethods(BindingFlags.Instance
                                  | BindingFlags.Public
                                  | BindingFlags.NonPublic
                                  | BindingFlags.FlattenHierarchy)
                      .Where(m => m.IsDefined(typeof(MakeButtonAttribute), true));

      List<InspectorMethodButtonData> inspectorMethodButtonData = new List<InspectorMethodButtonData>();
      foreach (var methodInfo in methodInfos) {
        inspectorMethodButtonData.Add(new InspectorMethodButtonData(methodInfo));
      }

      this._inspectorMethodButtonData = inspectorMethodButtonData.ToArray();

      // the vector editor needs to find any fields with the VectorInspectable attribute and validate them
      this._vectorInspectibleFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                      .Where(f => f.IsDefined(typeof(VectorInspectable), false))
                                      .Where(f => f.IsPublic || f.IsDefined(typeof(SerializeField), false));
      this._hasVectorFields = this._vectorInspectibleFields.Count() > 0;

      // the local vector editor needs to find any fields with the LocalVectorInspectable attribute and validate them
      this._localVectorInspectibleFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                      .Where(f => f.IsDefined(typeof(LocalVectorInspectable), false))
                                      .Where(f => f.IsPublic || f.IsDefined(typeof(SerializeField), false));
      this._hasLocalVectorFields = this._localVectorInspectibleFields.Count() > 0;
    }

    public override void OnInspectorGUI() {
      this.DrawDefaultInspector();

      if (this._onInspectorGuiMethod != null) {
        foreach (var target in targets)
        this._onInspectorGuiMethod.Invoke(target, new object[0]);
      }

      foreach (InspectorMethodButtonData methodButtonData in this._inspectorMethodButtonData) {
        GUILayout.BeginVertical(this.MethodGroupStyle);
          float oldFieldWidth = EditorGUIUtility.fieldWidth;
          GUIStyle methodNameStyle = new GUIStyle(GUI.skin.label);
          methodNameStyle.richText = true;

          string methodName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Regex.Replace(methodButtonData.method.Name, "(\\B[A-Z])", " $1"));
          EditorGUILayout.LabelField("<b>" + methodName + "</b>", methodNameStyle);

          GUILayout.BeginHorizontal();
            for (int i = 0; i < methodButtonData.parameters.Length; i++) {
              ParameterInfo parameter = methodButtonData.parameters[i];

              EditorGUIUtility.fieldWidth = 100.0f;
              EditorGUIUtility.labelWidth = GUI.skin.label.CalcSize(new GUIContent(parameter.Name)).x + 5.0f;

              float paramWidth = EditorGUIUtility.fieldWidth + EditorGUIUtility.labelWidth;

              if (parameter.ParameterType == typeof(int)) {
                methodButtonData.parameterArguments[i] = EditorGUILayout.IntField(parameter.Name, (int)methodButtonData.parameterArguments[i], GUILayout.Width(paramWidth));
              } else if (parameter.ParameterType == typeof(float)) {
                methodButtonData.parameterArguments[i] = EditorGUILayout.FloatField(parameter.Name, (float)methodButtonData.parameterArguments[i], GUILayout.Width(paramWidth));
              } else if (parameter.ParameterType == typeof(string)) {
                methodButtonData.parameterArguments[i] = EditorGUILayout.TextField(parameter.Name, (string)methodButtonData.parameterArguments[i], GUILayout.Width(paramWidth));
              } else {
                EditorGUILayout.LabelField("Unsupported type: " + parameter.Name);
              }
            }
          GUILayout.EndHorizontal();

          if (GUILayout.Button("Invoke", GUILayout.Width(200))) {
            // if method button pressed
            foreach (var eachTarget in targets) {
              methodButtonData.method.Invoke(eachTarget, methodButtonData.parameterArguments);
            }
          }

          EditorGUIUtility.fieldWidth = oldFieldWidth;
          EditorGUIUtility.labelWidth = 0.0f;
        GUILayout.EndVertical();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
      }
    }

    protected virtual void OnSceneGUI() {
      if (this._onSceneGuiMethod != null) {
        this._onSceneGuiMethod.Invoke(target, new object[0]);
      }

      if (this._hasVectorFields) {
        this.VectorOnSceneGUI();
      }

      if (this._hasLocalVectorFields) {
        this.LocalVectorOnSceneGUI();
      }
    }

    protected void VectorOnSceneGUI() {
      Undo.RecordObject(target, "Vector Editor");
      this.DisplayVectorFields(this._vectorInspectibleFields);
    }

    protected void LocalVectorOnSceneGUI() {
      Undo.RecordObject(target, "Local Vector Editor");
      this.DisplayVectorFields(this._localVectorInspectibleFields, (target as MonoBehaviour).gameObject.transform.position);
    }

    protected void DisplayVectorFields(IEnumerable<FieldInfo> fields, Vector3 offset = default(Vector3)) {
      foreach (var field in fields) {
        var value = field.GetValue(target);
        if (value is Vector3 || value is Vector2) {
          Vector3 val = Vector3.zero;
          if (value is Vector2) {
            Vector2 tempVal = (Vector2)value;
            val = (Vector3)tempVal;
          } else {
            val = (Vector3)value;
          }
          Handles.Label(val + offset, field.Name);
          Vector3 newValue = Handles.PositionHandle(val + offset, Quaternion.identity) - offset;
          if (GUI.changed) {
            GUI.changed = false;
            if (value is Vector3) {
              field.SetValue(target, newValue);
            } else {
              field.SetValue(target, (Vector2)newValue);
            }

            if (this._updateMethod != null) {
              this._updateMethod.Invoke(target, new object[0]);
            }
            if (this._onValidateMethod != null) {
              this._onValidateMethod.Invoke(target, new object[0]);
            }
            EditorUtility.SetDirty(target);
          }
        } else if (value is List<Vector3>) {
          var list = value as List<Vector3>;
          var label = field.Name + ": ";

          for (var i = 0; i < list.Count; i++) {
            Handles.Label(list[i] + offset, label + i);
            list[i] = Handles.PositionHandle(list[i] + offset, Quaternion.identity) - offset;
          }
          Handles.DrawPolyLine(list.ToArray());
        } else if (value is List<Vector2>) {
          List<Vector2> vec2List = value as List<Vector2>;
          List<Vector3> vec3List = new List<Vector3>();
          foreach (Vector2 vec2 in vec2List) {
            vec3List.Add(vec2);
          }
          var label = field.Name + ": ";

          for (var i = 0; i < vec3List.Count; i++) {
            Handles.Label(vec3List[i] + offset, label + i);
            vec2List[i] = (Vector2)(Handles.PositionHandle(vec3List[i] + offset, Quaternion.identity) - offset);
          }
          Handles.DrawPolyLine(vec3List.ToArray());
        } else if (value is Vector3[]) {
          var list = value as Vector3[];
          var label = field.Name + ": ";

          for (var i = 0; i < list.Length; i++) {
            Handles.Label(list[i] + offset, label + i);
            list[i] = Handles.PositionHandle(list[i] + offset, Quaternion.identity) - offset;
          }
          Handles.DrawPolyLine(list);
        } else if (value is Vector2[]) {
          Vector2[] vec2Array = value as Vector2[];
          Vector3[] vec3Array = new Vector3[vec2Array.Length];
          for (int i = 0; i < vec2Array.Length; i++) {
            vec3Array[i] = (Vector3)vec2Array[i];
          }
          var label = field.Name + ": ";

          for (var i = 0; i < vec3Array.Length; i++) {
            Handles.Label(vec3Array[i] + offset, label + i);
            vec2Array[i] = (Vector2)(Handles.PositionHandle(vec3Array[i] + offset, Quaternion.identity) - offset);
          }
          Handles.DrawPolyLine(vec3Array);
        }
      }
    }
  }
}
#endif