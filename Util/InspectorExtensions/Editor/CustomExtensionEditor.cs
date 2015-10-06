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
  /// for fields to work with the Vector3 inspector they must either be public or marked with SerializeField and have the VectorInspectable
  /// attribute.
  /// </summary>
  [CustomEditor(typeof(UnityEngine.Object), true)]
  [CanEditMultipleObjects]
  public class CustomExtensionEditor : Editor {
    MethodInfo _onInspectorGuiMethod;
    MethodInfo _onSceneGuiMethod;
    MethodInfo _updateMethod;
    List<MethodInfo> _buttonMethods = new List<MethodInfo>();
    
    // Vector editor
    bool _hasVectorFields = false;
    IEnumerable<FieldInfo> _vectorInspectibleFields;
    
    public void OnEnable() {
      var type = target.GetType();
      if (!typeof(ICustomEditor).IsAssignableFrom(type)) {
        return;
      }
      
      _onInspectorGuiMethod = type.GetMethod("OnInspectorGUI", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      _onSceneGuiMethod = type.GetMethod("OnSceneGUI", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      if (type.IsDefined(typeof(ExecuteInEditMode), false)) {
        _updateMethod = target.GetType().GetMethod("Update", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      }
      
      var meths = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                      .Where(m => m.IsDefined(typeof(MakeButtonAttribute), false));
      foreach (var meth in meths) {
        _buttonMethods.Add(meth);
      }
      
      // the vector3 editor needs to find any fields with the VectorInspectable attribute and validate them
      _vectorInspectibleFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                      .Where(f => f.IsDefined(typeof(VectorInspectable), false))
                                      .Where(f => f.IsPublic || f.IsDefined(typeof(SerializeField), false));
      _hasVectorFields = _vectorInspectibleFields.Count() > 0;
    }
    
    public override void OnInspectorGUI() {
      this.DrawDefaultInspector();
      
      if (_onInspectorGuiMethod != null) {
        foreach (var target in targets)
        _onInspectorGuiMethod.Invoke(target, new object[0]);
      }
      
      foreach (var meth in _buttonMethods) {
        if (GUILayout.Button(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(Regex.Replace(meth.Name, "(\\B[A-Z])", " $1")))) {
          // if method button pressed
          foreach (var eachTarget in targets) {
            meth.Invoke(eachTarget, new object[0]);
          }
        }
      }
    }
    
    protected virtual void OnSceneGUI() {
      if (_onSceneGuiMethod != null) {
        _onSceneGuiMethod.Invoke(target, new object[0]);
      }
      
      if (_hasVectorFields) {
        this.VectorOnSceneGUI();
      }
    }
    
    protected void VectorOnSceneGUI() {
      Undo.RecordObject(target, "Vector Editor");
      
      foreach (var field in _vectorInspectibleFields) {
        var value = field.GetValue(target);
        if (value is Vector3 || value is Vector2) {
          Vector3 val = Vector3.zero;
          if (value is Vector2) {
            Vector2 tempVal = (Vector2)value;
            val = (Vector3)tempVal;
          } else {
            val = (Vector3)value;
          }
          Handles.Label(val, field.Name);
          Vector3 newValue = Handles.PositionHandle(val, Quaternion.identity);
          if (GUI.changed) {
            GUI.changed = false;
            if (value is Vector3) {
              field.SetValue(target, newValue);
            } else {
              field.SetValue(target, (Vector2)newValue);
            }
            
            if (_updateMethod != null) {
              _updateMethod.Invoke(target, new object[0]);
            }
          }
        } else if (value is List<Vector3>) {
          var list = value as List<Vector3>;
          var label = field.Name + ": ";
          
          for (var i = 0; i < list.Count; i++) {
            Handles.Label(list[i], label + i);
            list[i] = Handles.PositionHandle(list[i], Quaternion.identity);
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
            Handles.Label(vec3List[i], label + i);
            vec2List[i] = (Vector2)Handles.PositionHandle(vec3List[i], Quaternion.identity);
          }
          Handles.DrawPolyLine(vec3List.ToArray());
        } else if (value is Vector3[]) {
          var list = value as Vector3[];
          var label = field.Name + ": ";
          
          for (var i = 0; i < list.Length; i++) {
            Handles.Label(list[i], label + i);
            list[i] = Handles.PositionHandle(list[i], Quaternion.identity);
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
            Handles.Label(vec3Array[i], label + i);
            vec2Array[i] = (Vector2)Handles.PositionHandle(vec3Array[i], Quaternion.identity);
          }
          Handles.DrawPolyLine(vec3Array);
        }
      }
    }
  }
}
#endif