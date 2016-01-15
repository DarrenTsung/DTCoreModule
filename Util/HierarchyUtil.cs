#if UNITY_EDITOR
using DT;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace DT {
  [OpenableClass]
  public static class HierarchyUtil {
    public enum FoldValue {
      EXPANDED,
      COLLAPSED
    }

    public static bool BoolValue(this FoldValue fv) {
      switch (fv) {
        case FoldValue.EXPANDED:
          return true;
        case FoldValue.COLLAPSED:
        default:
          return false;
      }
    }

    [OpenableMethod]
    [MenuItem("DarrenTsung/Hiearchy Utilities/Collapse All Objects In Hierarchy Except Currently Selected")]
    public static void CollapseAllObjectsInHierarchyExceptCurrentlySelected() {
      HierarchyUtil.SetFoldValueForAllGameObjectsInHiearchy(FoldValue.COLLAPSED);
      HierarchyUtil.SetFoldValueForGameObjectInHiearchyRecursive(Selection.activeGameObject, FoldValue.EXPANDED);
    }

    [OpenableMethod]
    [MenuItem("DarrenTsung/Hiearchy Utilities/Collapse All Objects In Hierarchy")]
    public static void CollapseAllObjectsInHierarchy() {
      HierarchyUtil.SetFoldValueForAllGameObjectsInHiearchy(FoldValue.COLLAPSED);
    }

    [OpenableMethod]
    [MenuItem("DarrenTsung/Hiearchy Utilities/Expand All Objects In Hierarchy")]
    public static void ExpandAllObjectsInHierarchy() {
      HierarchyUtil.SetFoldValueForAllGameObjectsInHiearchy(FoldValue.EXPANDED);
    }

    private static void SetFoldValueForAllGameObjectsInHiearchy(FoldValue fv) {
      var toplevelGos = Object.FindObjectsOfType<GameObject>().Where(g => g.transform.parent == null);

      foreach (GameObject g in toplevelGos) {
        HierarchyUtil.SetFoldValueForGameObjectInHiearchyRecursive(g, fv);
      }
    }

    private static void SetFoldValueForGameObjectInHiearchyRecursive(GameObject gameObject, FoldValue fv) {
      var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
      var methodInfo = type.GetMethod("SetExpandedRecursive");

      EditorApplication.ExecuteMenuItem("Window/Hierarchy");
      EditorWindow window = EditorWindow.focusedWindow;

      methodInfo.Invoke(window, new object[] {
        gameObject.GetInstanceID(),
        fv.BoolValue()
      });
    }
  }
}
#endif