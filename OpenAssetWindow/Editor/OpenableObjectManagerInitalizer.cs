using UnityEditor;

namespace DT {
  [InitializeOnLoad]
	public static class OpenableObjectManagerInitializer {
    // PRAGMA MARK - Static
    static OpenableObjectManagerInitializer() {
      OpenableObjectManager.AddLoader(new OpenablePrefabObjectLoader());
      OpenableObjectManager.AddLoader(new OpenableSceneObjectLoader());
      OpenableObjectManager.AddLoader(new SelectableGameObjectLoader());
      OpenableObjectManager.AddLoader(new OpenableMethodLoader());
    }
  }
}
