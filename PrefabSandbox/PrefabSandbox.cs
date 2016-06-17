#if UNITY_EDITOR
﻿using DT;
using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
﻿using UnityEngine;
﻿using UnityEngine.SceneManagement;

namespace DT.Prefab {
	[InitializeOnLoad]
	public class PrefabSandbox {
		public delegate void PrefabSandboxSetupCompleteCallback(bool success);

		private const string kSandboxSceneName = "PrefabSandbox";
		private const string kSandboxSetupPrefabName = "PrefabSandboxSetupPrefab";

		public class PrefabSandboxData {
			public string PrefabGuid;
			public string PrefabPath;
			public GameObject PrefabAsset;

			public GameObject PrefabInstance;
			public int PrefabInstanceId;

			public bool SceneIsDirty;
		}

		private static PrefabSandboxData _data;
		private static GameObject _newPrefab;
		private static PrefabSandboxSetupCompleteCallback _setupCompletionCallback;
		private static bool _isSavingScene;
    private static Scene _sandboxScene;
    private static string _oldScenePath;

		private static string _sandboxScenePath;
		private static GameObject _sandboxSetupPrefab;

		static PrefabSandbox() {
			PrefabSandbox._sandboxScenePath = PrefabSandbox.FindSandboxPath();
			string sandboxSetupPrefabPath = PrefabSandbox.FindSandboxSetupPrefabPath();
			PrefabSandbox._sandboxSetupPrefab = AssetDatabase.LoadAssetAtPath(sandboxSetupPrefabPath, typeof(GameObject)) as GameObject;

			EditorApplicationUtil.SceneDirtied += PrefabSandbox.OnSceneDirtied;
			EditorApplicationUtil.SceneSaved += PrefabSandbox.OnSceneSave;
			EditorApplicationUtil.OnSceneGUIDelegate += PrefabSandbox.OnSceneGUI;
		}


		// PRAGMA MARK - Public Interface
		public static bool OpenPrefab(string guid, PrefabSandboxSetupCompleteCallback callback) {
			string assetPath = AssetDatabase.GUIDToAssetPath(guid);
			GameObject prefab = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

			return PrefabSandbox.OpenPrefab(prefab, callback);
		}

		public static bool OpenPrefab(GameObject prefab, PrefabSandboxSetupCompleteCallback callback) {
			string assetPath = AssetDatabase.GetAssetPath(prefab);
			string guid = AssetDatabase.AssetPathToGUID(assetPath);

			bool alreadyEditing = (PrefabSandbox._data != null && PrefabSandbox._data.PrefabGuid == guid);
			PrefabSandbox._setupCompletionCallback = callback;

			if (prefab != null && assetPath != null && PathUtil.IsPrefab(assetPath) && !alreadyEditing) {
				PrefabSandbox._data = new PrefabSandboxData();
				PrefabSandbox._data.PrefabGuid = guid;
				PrefabSandbox._data.PrefabPath = assetPath;
				PrefabSandbox._data.PrefabAsset = prefab;

				PrefabSandbox.SetupSandbox();
				return true;
			} else {
				if (PrefabSandbox._setupCompletionCallback != null) {
					PrefabSandbox._setupCompletionCallback(success: false);
				}
				return false;
			}
		}

		public static void SavePrefabAsset() {
			if (PrefabSandbox._data != null && PrefabSandbox._data.PrefabInstance != null && PrefabSandbox._data.PrefabAsset != null) {
				string newPath = PrefabSandbox._data.PrefabPath.RemoveSubstring(Path.GetFileName(PrefabSandbox._data.PrefabPath));
				newPath = newPath + PrefabSandbox._data.PrefabInstance.name + Path.GetExtension(PrefabSandbox._data.PrefabPath);

				UnityEditor.AnimationMode.StopAnimationMode();

				PrefabUtility.ReplacePrefab(PrefabSandbox._data.PrefabInstance, PrefabSandbox._data.PrefabAsset, ReplacePrefabOptions.Default);
				PrefabUtility.DisconnectPrefabInstance(PrefabSandbox._data.PrefabInstance);
				AssetDatabase.MoveAsset(PrefabSandbox._data.PrefabPath, newPath);

				PrefabSandbox.SaveScene();

				PrefabSandbox._data.SceneIsDirty = false;
				SceneView.RepaintAll();
			}
		}

		public static bool IsEditing() {
			return PrefabSandbox._data != null;
		}


		// PRAGMA MARK - Internal


		// PRAGMA MARK - Editor Callbacks
		private static void OnSceneDirtied() {
			if (PrefabSandbox._data != null) {
				PrefabSandbox._data.SceneIsDirty = true;
				SceneView.RepaintAll();
			}
		}

		private static void OnSceneSave() {
			// if _isSavingScene is true, then we initiated the scene save
			// and don't need to save the prefab asset
			if (!PrefabSandbox._isSavingScene) {
				PrefabSandbox.SavePrefabAsset();
			}
		}

		public const float kSceneButtonHeight = 20.0f;
		public const float kSceneButtonHeightPadding = 5.0f;

		public const float kPreviousSceneButtonWidth = 120.0f;
		public const float kSaveButtonWidth = 80.0f;
		public const float kRevertButtonWidth = 80.0f;

		private static void OnSceneGUI(SceneView sceneView) {
			if (!PrefabSandbox.IsEditing()) {
				return;
			}

			Handles.BeginGUI();

			Color previousColor = GUI.color;

			// BEGIN SCENE GUI
			GUI.color = Color.green;
			if (GUI.Button(new Rect(sceneView.position.size.x - PrefabSandbox.kPreviousSceneButtonWidth, 0.0f, PrefabSandbox.kPreviousSceneButtonWidth, PrefabSandbox.kSceneButtonHeight), "Close Sandbox Scene")) {
				PrefabSandbox.CloseSandboxScene();
			}

			if (GUI.Button(new Rect(0.0f, 0.0f, PrefabSandbox.kSaveButtonWidth, PrefabSandbox.kSceneButtonHeight), "Save")) {
				PrefabSandbox.SavePrefabAsset();
			}

			GUI.color = Color.red;
			if (GUI.Button(new Rect(0.0f, PrefabSandbox.kSceneButtonHeight + PrefabSandbox.kSceneButtonHeightPadding, PrefabSandbox.kRevertButtonWidth, PrefabSandbox.kSceneButtonHeight), "Revert")) {
				if (EditorUtility.DisplayDialog("Discard Changes?", "Would you like to revert all changes since last save?", "Discard Changes", "Keep Changes")) {
					PrefabSandbox.CreatePrefabInstance();
				}
			}
			// END SCENE GUI

			GUI.color = previousColor;
			GUI.enabled = true;

			Handles.EndGUI();
		}

		// PRAGMA MARK - Setup
		protected static string FindSandboxPath() {
			string guid = AssetDatabaseUtil.FindSpecificAsset(PrefabSandbox.kSandboxSceneName + " t:Scene");
			string path = AssetDatabase.GUIDToAssetPath(guid);
			if (PathUtil.IsScene(path)) {
				return path;
			} else {
				throw new Exception(string.Format("Path for sandbox scene ({0}) is not a scene", path));
			}
		}

		protected static string FindSandboxSetupPrefabPath() {
			string guid = AssetDatabaseUtil.FindSpecificAsset(PrefabSandbox.kSandboxSetupPrefabName + " t:Prefab");
			string path = AssetDatabase.GUIDToAssetPath(guid);
			if (PathUtil.IsPrefab(path)) {
				return path;
			} else {
				throw new Exception(string.Format("Path for sandbox setup prefab ({0}) is not a prefab", path));
			}
		}

		protected static void SetupSandbox() {
      PrefabSandbox._oldScenePath = EditorSceneManager.GetActiveScene().path;
      PrefabSandbox._sandboxScene = EditorSceneManager.OpenScene(PrefabSandbox._sandboxScenePath);
      EditorSceneManager.SetActiveScene(PrefabSandbox._sandboxScene);

			if (PrefabSandbox._sandboxScene.isLoaded) {
				PrefabSandbox.SaveScene();
				PrefabSandbox.ClearAllGameObjectsInSandbox();

				// setup scene with sandbox setup prefab
				PrefabUtility.InstantiatePrefab(PrefabSandbox._sandboxSetupPrefab);

				if (!PrefabSandbox.CreatePrefabInstance()) {
					PrefabSandbox.CloseSandboxScene();
					return;
				}
			} else {
				throw new Exception(string.Format("Sandbox Scene ({0}) was not able to be opened!", PrefabSandbox._sandboxScenePath));
			}
		}

		protected static void SaveScene() {
			PrefabSandbox._isSavingScene = true;
			EditorSceneManager.SaveScene(PrefabSandbox._sandboxScene);
			PrefabSandbox._isSavingScene = false;
		}

		protected static void CloseSandboxScene() {
			if (PrefabSandbox._data == null) {
				return;
			}

			PrefabSandbox.ClearAllGameObjectsInSandbox();
			PrefabSandbox.SaveScene();

			EditorSceneManager.OpenScene(PrefabSandbox._oldScenePath);
			PrefabSandbox._data = null;
		}

		protected static bool CreatePrefabInstance() {
			if (PrefabSandbox._data.PrefabInstance != null) {
				GameObject.DestroyImmediate(PrefabSandbox._data.PrefabInstance);
			}

			PrefabSandbox._data.PrefabInstance = PrefabUtility.InstantiatePrefab(PrefabSandbox._data.PrefabAsset) as GameObject;
			PrefabUtility.DisconnectPrefabInstance(PrefabSandbox._data.PrefabInstance);
			PrefabSandbox._data.PrefabInstanceId = PrefabSandbox._data.PrefabInstance.GetInstanceID();

      // if the prefab is a UI element, child it under the canvas
      if (PrefabSandbox._data.PrefabInstance.GetComponent<RectTransform>() != null) {
        PrefabSandbox._data.PrefabInstance.transform.SetParent(CanvasUtil.ScreenSpaceMainCanvas.transform, worldPositionStays : false);
      }

			Selection.activeGameObject = PrefabSandbox._data.PrefabInstance;
      HierarchyUtil.ExpandCurrentSelectedObjectInHierarchy();

			return true;
		}

		protected static void ClearAllGameObjectsInSandbox() {
			foreach (GameObject obj in PrefabSandbox._sandboxScene.GetRootGameObjects()) {
				GameObject.DestroyImmediate(obj);
			}
		}
	}
}
#endif