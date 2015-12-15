using System.IO;
using UnityEditor;
using UnityEngine;

namespace DT {
  public class SelectableGameObject : OpenableGameObject {
    private static Texture2D _selectableGameObjectDisplayIcon;
    private static Texture2D SelectableGameObjectDisplayIcon {
      get {
        if (_selectableGameObjectDisplayIcon == null) {
          _selectableGameObjectDisplayIcon = AssetDatabase.LoadAssetAtPath(OpenObjectWindow.ScriptDirectory + "/Icons/GameObjectIcon.png", typeof(Texture2D)) as Texture2D;
        }
        return _selectableGameObjectDisplayIcon ?? new Texture2D(0, 0);
      }
    }
    
    // PRAGMA MARK - IOpenableObject
    public override Texture2D DisplayIcon {
      get {
        return SelectableGameObject.SelectableGameObjectDisplayIcon;
      }
    }
    
    public override void Open() {
      Selection.activeGameObject = _obj;
    }
    
    
    // PRAGMA MARK - Constructors
    public SelectableGameObject(GameObject obj) : base(obj) {
    }
  }
}