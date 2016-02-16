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

		private static string _sandboxScenePath;
		private static GameObject _sandboxSetupPrefab;

		static PrefabSandbox() {
			_sandboxScenePath = PrefabSandbox.FindSandboxPath();
			string sandboxSetupPrefabPath = PrefabSandbox.FindSandboxSetupPrefabPath();
			_sandboxSetupPrefab = AssetDatabase.LoadAssetAtPath(sandboxSetupPrefabPath, typeof(GameObject)) as GameObject;

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

			bool alreadyEditing = (_data != null && _data.PrefabGuid == guid);
			_setupCompletionCallback = callback;

			if (prefab != null && assetPath != null && PathUtil.IsPrefab(assetPath) && !alreadyEditing) {
				_data = new PrefabSandboxData();
				_data.PrefabGuid = guid;
				_data.PrefabPath = assetPath;
				_data.PrefabAsset = prefab;

				PrefabSandbox.SetupSandbox();
				return true;
			} else {
				if (_setupCompletionCallback != null) {
					_setupCompletionCallback(success: false);
				}
				return false;
			}
		}

		public static void SavePrefabAsset() {
			if (_data != null && _data.PrefabInstance != null && _data.PrefabAsset != null) {
				string newPath = _data.PrefabPath.RemoveSubstring(Path.GetFileName(_data.PrefabPath));
				newPath = newPath + _data.PrefabInstance.name + Path.GetExtension(_data.PrefabPath);

				UnityEditor.AnimationMode.StopAnimationMode();

				PrefabUtility.ReplacePrefab(_data.PrefabInstance, _data.PrefabAsset, ReplacePrefabOptions.Default);
				PrefabUtility.DisconnectPrefabInstance(_data.PrefabInstance);
				AssetDatabase.MoveAsset(_data.PrefabPath, newPath);

				PrefabSandbox.SaveScene();

				_data.SceneIsDirty = false;
				SceneView.RepaintAll();
			}
		}

		public static bool IsEditing() {
			return _data != null;
		}


		// PRAGMA MARK - Internal


		// PRAGMA MARK - Editor Callbacks
		private static void OnSceneDirtied() {
			if (_data != null) {
				_data.SceneIsDirty = true;
				SceneView.RepaintAll();
			}
		}

		private static void OnSceneSave() {
			// if _isSavingScene is true, then we initiated the scene save
			// and don't need to save the prefab asset
			if (!_isSavingScene) {
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
			if (GUI.Button(new Rect(sceneView.position.size.x - kPreviousSceneButtonWidth, 0.0f, kPreviousSceneButtonWidth, kSceneButtonHeight), "Close Sandbox Scene")) {
				PrefabSandbox.CloseSandboxScene();
			}

			if (GUI.Button(new Rect(0.0f, 0.0f, kSaveButtonWidth, kSceneButtonHeight), "Save")) {
				PrefabSandbox.SavePrefabAsset();
			}

			GUI.color = Color.red;
			if (GUI.Button(new Rect(0.0f, kSceneButtonHeight + kSceneButtonHeightPadding, kRevertButtonWidth, kSceneButtonHeight), "Revert")) {
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
			string guid = AssetDatabaseUtil.FindSpecificAsset(kSandboxSceneName + " t:Scene");
			string path = AssetDatabase.GUIDToAssetPath(guid);
			if (PathUtil.IsScene(path)) {
				return path;
			} else {
				throw new Exception(string.Format("Path for sandbox scene ({0}) is not a scene", path));
			}
		}

		protected static string FindSandboxSetupPrefabPath() {
			string guid = AssetDatabaseUtil.FindSpecificAsset(kSandboxSetupPrefabName + " t:Prefab");
			string path = AssetDatabase.GUIDToAssetPath(guid);
			if (PathUtil.IsPrefab(path)) {
				return path;
			} else {
				throw new Exception(string.Format("Path for sandbox setup prefab ({0}) is not a prefab", path));
			}
		}

		protected static void SetupSandbox() {
      _sandboxScene = EditorSceneManager.OpenScene(_sandboxScenePath, OpenSceneMode.Additive);
      EditorSceneManager.SetActiveScene(_sandboxScene);

			if (_sandboxScene.isLoaded) {
				PrefabSandbox.SaveScene();
				PrefabSandbox.ClearAllGameObjectsInSandbox();

				// setup scene with sandbox setup prefab
				PrefabUtility.InstantiatePrefab(_sandboxSetupPrefab);

				if (!PrefabSandbox.CreatePrefabInstance()) {
					PrefabSandbox.CloseSandboxScene();
					return;
				}
			} else {
				throw new Exception(string.Format("Sandbox Scene ({0}) was not able to be opened!", _sandboxScenePath));
			}
		}

		protected static void SaveScene() {
			_isSavingScene = true;
			EditorSceneManager.SaveScene(_sandboxScene);
			_isSavingScene = false;
		}

		protected static void CloseSandboxScene() {
			if (_data == null) {
				return;
			}

			PrefabSandbox.ClearAllGameObjectsInSandbox();
			PrefabSandbox.SaveScene();

			EditorSceneManager.CloseScene(_sandboxScene, true);
			_data = null;
		}

		protected static bool CreatePrefabInstance() {
			if (_data.PrefabInstance != null) {
				GameObject.DestroyImmediate(_data.PrefabInstance);
			}

			_data.PrefabInstance = PrefabUtility.InstantiatePrefab(_data.PrefabAsset) as GameObject;
			PrefabUtility.DisconnectPrefabInstance(_data.PrefabInstance);
			_data.PrefabInstanceId = _data.PrefabInstance.GetInstanceID();

			Selection.activeGameObject = _data.PrefabInstance;

			return true;
		}

		protected static void ClearAllGameObjectsInSandbox() {
			foreach (GameObject obj in _sandboxScene.GetRootGameObjects()) {
				GameObject.DestroyImmediate(obj);
			}
		}
	}
}
#endif