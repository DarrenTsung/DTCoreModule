using System.IO;
using UnityEngine;
using UnityEditor;

namespace DT {
  public abstract class OpenableAsset : IOpenableObject {
    // PRAGMA MARK - IOpenableObject
    public string DisplayName {
      get {
        return _assetFileName;
      }
    }
    
    public abstract void Open();
    
    
    // PRAGMA MARK - Constructors
    public OpenableAsset(string guid) {
      _guid = guid;
  		_assetFileName = Path.GetFileName(AssetDatabase.GUIDToAssetPath(_guid));
  		_path = AssetDatabase.GUIDToAssetPath(_guid);
    }
    
    
    // PRAGMA MARK - Internal
    protected string _guid;
    protected string _assetFileName;
    protected string _path;
  }
}