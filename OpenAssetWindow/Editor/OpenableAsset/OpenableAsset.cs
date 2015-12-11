using System.IO;
using UnityEngine;
using UnityEditor;

namespace DT {
  public abstract class OpenableAsset : IOpenableObject {
    // PRAGMA MARK - IOpenableObject
    public string DisplayTitle {
      get {
        return _assetFileName;
      }
    }
    
    public string DisplayDetailText {
      get {
        return _path;
      }
    }
    
    public abstract Texture2D DisplayIcon {
      get;
    }
    
    public abstract void Open();
    
    
    // PRAGMA MARK - Constructors
    public OpenableAsset(string guid) {
      _guid = guid;
  		_path = AssetDatabase.GUIDToAssetPath(_guid);
  		_assetFileName = Path.GetFileName(_path);
    }
    
    
    // PRAGMA MARK - Internal
    protected string _guid;
    protected string _assetFileName;
    protected string _path;
  }
}