using DT;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace DT {
  // Commenting this out because it doesn't work...
  // [OpenableClass]
  public static class HierarchyUtil {
    public enum FoldValue {
      EXPANDED,
      COLLAPSED
    }
    
    private static void SetFocusedWindow(string windowName) {
      EditorApplication.ExecuteMenuItem("Window/" + windowName);
    }
    
    public static void SetFoldValueForObjectInCurrentWindow(Object obj, FoldValue foldValue) {
      // get a reference to the wanted window 
      var window = EditorWindow.focusedWindow;
      
      // set selected object
      Selection.activeObject = obj;
      
      KeyCode foldValueKey = (foldValue == FoldValue.EXPANDED) ? KeyCode.RightArrow : KeyCode.LeftArrow;
      
      // create a new key event (RightArrow for collapsing, LeftArrow for folding)
      var key = new Event {
        alt = true,
        keyCode = foldValueKey,
        type = EventType.keyDown 
      };
      
      // finally, send the event to the window
      window.SendEvent(key);
    }
    
    [OpenableMethod]
		[MenuItem("DarrenTsung/CollapseAllObjectsInHierarchyExceptCurrentlySelected")]
    public static void CollapseAllObjectsInHierarchyExceptCurrentlySelected() {
      HierarchyUtil.CollapseAllObjectsInHierarchyExcept(Selection.activeObject as GameObject);
    }
    
    [OpenableMethod]
		[MenuItem("DarrenTsung/ExpandAllObjectsInHierarchy")]
    public static void ExpandAllObjectsInHierarchy() {
      var toplevelGos = Object.FindObjectsOfType<GameObject>().Where(g => g.transform.parent == null);
      
      HierarchyUtil.SetFocusedWindow("Hierarchy");
      foreach (GameObject g in toplevelGos) {
        HierarchyUtil.SetFoldValueForObjectInCurrentWindow(g, FoldValue.EXPANDED);
      }
    }
    
    public static void CollapseAllObjectsInHierarchyExcept(GameObject go) {
      // get the toplevel GOs (whose parents are null) - exclude 'go'
      var toplevelGos = Object.FindObjectsOfType<GameObject>().Where(g => g.transform.parent == null && g != go);
      
      HierarchyUtil.SetFocusedWindow("Hierarchy");
      foreach (GameObject g in toplevelGos) {
        HierarchyUtil.SetFoldValueForObjectInCurrentWindow(g, FoldValue.COLLAPSED);
      }
      
      Selection.activeObject = go;
    }
  }
}