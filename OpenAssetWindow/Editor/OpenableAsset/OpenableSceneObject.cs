using System;
using UnityEditor;

namespace DT {
  public class OpenableSceneObject : OpenableAsset {
    // PRAGMA MARK - IOpenableObject
    public override void Open() {
			if (EditorApplication.isSceneDirty) {
				if (EditorApplication.SaveCurrentSceneIfUserWantsTo()) {
					EditorApplication.OpenScene(_path);
				}
			} else {
				EditorApplication.OpenScene(_path);
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