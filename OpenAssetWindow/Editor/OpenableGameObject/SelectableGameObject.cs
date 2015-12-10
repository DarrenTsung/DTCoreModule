using System.IO;
using UnityEngine;
using UnityEditor;

namespace DT {
  public class SelectableGameObject : OpenableGameObject {
    // PRAGMA MARK - IOpenableObject
    public override void Open() {
      Selection.activeGameObject = _obj;
    }
    
    
    // PRAGMA MARK - Constructors
    public SelectableGameObject(GameObject obj) : base(obj) {
    }
  }
}