using System.IO;
using UnityEngine;
using UnityEditor;

namespace DT {
  public abstract class OpenableGameObject : IOpenableObject {
    // PRAGMA MARK - IOpenableObject
    public string DisplayTitle {
      get {
        return _obj.name;
      }
    }
    
    public string DisplayDetailText {
      get {
        return _obj.FullName();
      }
    }
    
    public abstract Texture2D DisplayIcon {
      get;
    }
    
    public bool IsValid() {
      return _obj != null;
    }
    
    public abstract void Open();
    
    
    // PRAGMA MARK - Constructors
    public OpenableGameObject(GameObject obj) {
      _obj = obj;
    }
    
    
    // PRAGMA MARK - Internal
    protected GameObject _obj;
  }
}