#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DT {
  [OpenableClass]
  public class OpenableSelectionUtil {
    [OpenableMethod]
    public static void CreateEmptyChildOnSelectedGameObject() {
      GameObject obj = Selection.activeGameObject;
      if (obj == null) {
        return;
      }

      GameObject newChild = new GameObject();
      newChild.transform.SetParent(obj.transform);
      Selection.activeGameObject = newChild;
    }

    [OpenableMethod]
    public static void RenameSelectedGameObject(string name) {
      GameObject obj = Selection.activeGameObject;
      if (obj == null) {
        return;
      }

      obj.name = name;
    }
  }
}
#endif