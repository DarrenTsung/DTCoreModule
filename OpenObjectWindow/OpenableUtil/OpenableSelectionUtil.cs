#if UNITY_EDITOR
using System;
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

    [OpenableMethod]
    public static void EnableTopParentOfSelectedGameObject() {
        OpenableSelectionUtil.DoActionOnTopParentOfSelectedGameObject((GameObject topParent) => {
          topParent.SetActive(true);
        });
    }

    [OpenableMethod]
    public static void DisableTopParentOfSelectedGameObject() {
        OpenableSelectionUtil.DoActionOnTopParentOfSelectedGameObject((GameObject topParent) => {
          topParent.SetActive(false);
        });
    }

    public static void DoActionOnTopParentOfSelectedGameObject(Action<GameObject> action) {
      GameObject obj = Selection.activeGameObject;
      if (obj == null) {
        return;
      }

      Transform topParentTransform = obj.transform;
      while (topParentTransform.parent != null) {
        topParentTransform = topParentTransform.parent;
      }

      action.Invoke(topParentTransform.gameObject);
    }
  }
}
#endif