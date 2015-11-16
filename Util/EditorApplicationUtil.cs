using DT;
using System;
﻿using UnityEditor;
﻿using UnityEngine;

namespace DT {
  public class EditorApplicationUtilAssetModificationProcessor : UnityEditor.AssetModificationProcessor {
    public static string[] OnWillSaveAssets(string[] paths) {
      bool sceneSaved = false;
      foreach (string path in paths) {
        if (PathUtil.IsScene(path)) {
          sceneSaved = true;
          break;
        }
      }
      
      if (sceneSaved) {
        EditorApplicationUtil.SceneSaved();
      }
      
      return paths;
    }
  }
  
	public static class EditorApplicationUtil {
    public static Action<SceneView> OnSceneGUIDelegate = delegate(SceneView sceneView) {};
    public static Action SceneSaved = delegate {};
    public static Action SceneDirtied = delegate {};
    
    static EditorApplicationUtil() {
      EditorApplication.hierarchyWindowChanged += EditorApplicationUtil.HierarchyWindowChanged;
      SceneView.onSceneGUIDelegate += EditorApplicationUtil.OnSceneGUI;
      Undo.postprocessModifications += EditorApplicationUtil.PostProcessModifications;
    }
    
    private static int _objectCount = 0;
    private static void HierarchyWindowChanged() {
      int newObjectCount = GameObject.FindObjectsOfType<UnityEngine.Object>().Length;
      if (newObjectCount != _objectCount) {
        _objectCount = newObjectCount;
        EditorApplicationUtil.SceneDirtied();
      }
    }
    
    private static UndoPropertyModification[] PostProcessModifications(UndoPropertyModification[] propertyModifications) {
      EditorApplicationUtil.SceneDirtied();
      return propertyModifications;
    }
    
    private static void OnSceneGUI(SceneView sceneView) {
      EditorApplicationUtil.OnSceneGUIDelegate(sceneView);
    }
	}
}