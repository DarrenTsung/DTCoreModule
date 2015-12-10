using System.IO;
using UnityEngine;
using UnityEditor;

namespace DT {
  public abstract class OpenableGameObject : IOpenableObject {
    // PRAGMA MARK - IOpenableObject
    public string DisplayName {
      get {
        return _obj.name;
      }
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