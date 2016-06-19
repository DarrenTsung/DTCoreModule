using DT.Prefab;
using System;
using UnityEditor;
using UnityEngine;

namespace DT {
  public class OpenablePrefabObject : OpenableAsset {
    private static Texture2D _prefabDisplayIcon;
    private static Texture2D PrefabDisplayIcon {
      get {
        if (_prefabDisplayIcon == null) {
          _prefabDisplayIcon = AssetDatabase.LoadAssetAtPath(OpenObjectWindow.ScriptDirectory + "/Icons/PrefabIcon.png", typeof(Texture2D)) as Texture2D;
        }
        return _prefabDisplayIcon ?? new Texture2D(0, 0);
      }
    }

    // PRAGMA MARK - IOpenableObject
    public override Texture2D DisplayIcon {
      get {
        return OpenablePrefabObject.PrefabDisplayIcon;
      }
    }

    public override void Open() {
			PrefabSandbox.OpenPrefab(_guid);
    }


    // PRAGMA MARK - Constructors
    public OpenablePrefabObject(string guid) : base(guid) {
      if (!PathUtil.IsPrefab(_path)) {
        throw new ArgumentException("OpenablePrefabObject loaded with guid that's not a prefab!");
      }
    }
  }
}