using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace DT {
  public class OpenableSceneObject : OpenableAsset {
    private static Texture2D _sceneDisplayIcon;
    private static Texture2D SceneDisplayIcon {
      get {
        if (_sceneDisplayIcon == null) {
          _sceneDisplayIcon = AssetDatabase.LoadAssetAtPath(OpenObjectWindow.ScriptDirectory + "/Icons/SceneIcon.png", typeof(Texture2D)) as Texture2D;
        }
        return _sceneDisplayIcon ?? new Texture2D(0, 0);
      }
    }

    // PRAGMA MARK - IOpenableObject
    public override Texture2D DisplayIcon {
      get {
        return OpenableSceneObject.SceneDisplayIcon;
      }
    }

    public override void Open() {
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
        EditorSceneManager.OpenScene(this._path);
			}
    }


    // PRAGMA MARK - Constructors
    public OpenableSceneObject(string guid) : base(guid) {
      if (!PathUtil.IsScene(_path)) {
        throw new ArgumentException("OpenableSceneObject loaded with guid that's not a scene!");
      }
    }
  }
}