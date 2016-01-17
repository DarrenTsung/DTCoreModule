#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DT {
  [OpenableClass]
  public class OpenableEditorUtil {
    [OpenableMethod]
    public static void Quit() {
      if (!EditorApplication.isPlaying) {
        return;
      }

      EditorApplication.isPlaying = false;
    }

    [OpenableMethod]
    public static void Play() {
      if (EditorApplication.isPlaying) {
        return;
      }

      EditorApplication.isPlaying = true;
    }

    [OpenableMethod]
    public static void CreateTopLevelEmptyChild() {
      GameObject newObject = new GameObject();
      Selection.activeGameObject = newObject;
    }
  }
}
#endif