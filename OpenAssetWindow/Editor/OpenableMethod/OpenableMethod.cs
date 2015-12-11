using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace DT {
  public class OpenableMethodConfig {
    public MethodInfo methodInfo;
    public Type classType;
    public string methodDisplayName;
  }
  
  public class OpenableMethod : IOpenableObject {
    private static Texture2D _methodDisplayIcon;
    private static Texture2D MethodDisplayIcon {
      get {
        if (_methodDisplayIcon == null) {
          _methodDisplayIcon = AssetDatabase.LoadAssetAtPath(OpenAssetEditorWindow.EditorWindowScriptPath + "/Icons/FunctionIcon.png", typeof(Texture2D)) as Texture2D;
        }
        return _methodDisplayIcon ?? new Texture2D(0, 0);
      }
    }
    
    // PRAGMA MARK - IOpenableObject
    public string DisplayTitle {
      get {
        return _methodDisplayName;
      }
    }
    
    public string DisplayDetailText {
      get {
        if (_method.IsStatic) {
          return _classType.Name + "::" + _methodDisplayName;
        } else {
          return _classType.Name + "->" + _methodDisplayName;
        }
      }
    }
    
    public Texture2D DisplayIcon {
      get {
        return OpenableMethod.MethodDisplayIcon;
      }
    }
    
    public void Open() {
      if (_method.IsStatic) {
        _method.Invoke(null, new object[0]);
      } else {
        UnityEngine.Object[] objects = UnityEngine.Object.FindObjectsOfType(_classType);
        if (objects.Length > 0) {
          _method.Invoke(objects[0], new object[0]);
        } else {
          Debug.LogWarning("OpenableMethod: instance method couldn't find UnityEngine.Object instance matching type");
        }
      }
    }
    
    
    // PRAGMA MARK - Constructors
    public OpenableMethod(OpenableMethodConfig config) {
      _method = config.methodInfo;
      _methodDisplayName = config.methodDisplayName ?? _method.Name;
      _classType = config.classType;
    }
    
    
    // PRAGMA MARK - Internal
    protected MethodInfo _method;
    protected Type _classType;
    protected string _methodDisplayName;
  }
}