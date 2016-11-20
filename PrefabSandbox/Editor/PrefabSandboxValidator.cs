using DT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
	public class PrefabSandboxValidator : IDisposable {
    // PRAGMA MARK - Public Interface
    public void Dispose() {
      this._prefab = null;
      this._cachedValidationErrors = null;

			EditorApplicationUtil.OnSceneGUIDelegate -= this.OnSceneGUI;
      EditorApplicationUtil.SceneDirtied -= this.RefreshValidationErrors;
			EditorApplication.hierarchyWindowItemOnGUI -= this.OnHierarchyWindowItemOnGUI;
    }

    public PrefabSandboxValidator(GameObject prefab) {
      this._prefab = prefab;
      this.RefreshValidationErrors();

			EditorApplicationUtil.OnSceneGUIDelegate += this.OnSceneGUI;
      EditorApplicationUtil.SceneDirtied += this.RefreshValidationErrors;
			EditorApplication.hierarchyWindowItemOnGUI += this.OnHierarchyWindowItemOnGUI;
    }

    public bool RefreshAndCheckValiationErrors() {
      this.RefreshValidationErrors();
      return !this._cachedValidationErrors.IsNullOrEmpty();
    }


    // PRAGMA MARK - Internal
    private const float kErrorHeight = 20.0f;
    private const float kErrorSpacingHeight = 2.0f;
    private const float kErrorWidth = 275.0f;

    private static readonly Color kErrorColor = ColorUtil.HexStringToColor("#EA827A");

    private static GUIStyle _kButtonStyle = null;
    private static GUIStyle kButtonStyle {
      get {
        if (_kButtonStyle == null) {
          _kButtonStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
          _kButtonStyle.alignment = TextAnchor.MiddleRight;
        }
        return _kButtonStyle;
      }
    }

    private const float kErrorIconPadding = 3.0f;

    private static Texture2D _kErrorIconTexture = null;
    private static Texture2D kErrorIconTexture {
      get {
        if (_kErrorIconTexture == null) {
          string prefabSandboxPath = ScriptableObjectEditorUtil.PathForScriptableObjectType<PrefabSandboxMarker>();
          _kErrorIconTexture = AssetDatabaseUtil.LoadAssetAtPath<Texture2D>(prefabSandboxPath + "/Icons/ErrorIcon.png");// ?? new Texture2D(0, 0);
        }
        return _kErrorIconTexture;
      }
    }

    private GameObject _prefab;
    private IList<GameObjectValidator.ValidationError> _cachedValidationErrors;
    private HashSet<GameObject> _objectsWithErrors = new HashSet<GameObject>();

		private void OnSceneGUI(SceneView sceneView) {
      if (this._cachedValidationErrors == null) {
        return;
      }

      Handles.BeginGUI();
			Color previousColor = GUI.color;

			// BEGIN SCENE GUI
			GUI.color = kErrorColor;

      float yPosition = 0.0f;
      foreach (GameObjectValidator.ValidationError error in this._cachedValidationErrors) {
        // NOTE (darren): it's possible that OnSceneGUI gets called after
        // the prefab is destroyed - don't do anything in that case
        if (error.component == null) {
          continue;
        }

        var rect = new Rect(0.0f, yPosition, kErrorWidth, kErrorHeight);
        var errorDescription = string.Format("{0}->{1}->{2}", error.component.gameObject.name, error.componentType.Name, error.fieldInfo.Name);

        if (GUI.Button(rect, errorDescription, kButtonStyle)) {
          Selection.activeGameObject = error.component.gameObject;
        }

        yPosition += kErrorHeight + kErrorSpacingHeight;
      }
			// END SCENE GUI

			GUI.color = previousColor;
      Handles.EndGUI();
		}

    private void OnHierarchyWindowItemOnGUI(int instanceId, Rect selectionRect) {
      if (Event.current.type != EventType.Repaint) {
        return;
      }

      GameObject g = EditorUtility.InstanceIDToObject(instanceId) as GameObject;

      bool gameObjectHasError = this._objectsWithErrors.Contains(g);
      if (gameObjectHasError) {
        float edgeLength = selectionRect.height - (2.0f * kErrorIconPadding);
        Rect errorIconRect = new Rect(selectionRect.x + selectionRect.width - kErrorIconPadding - edgeLength,
                                      selectionRect.y + kErrorIconPadding,
                                      edgeLength,
                                      edgeLength);
        GUI.DrawTexture(errorIconRect, kErrorIconTexture);
        EditorApplication.RepaintHierarchyWindow();
      }
    }

    private void RefreshValidationErrors() {
      this._cachedValidationErrors = GameObjectValidator.Validate(this._prefab);

      this._objectsWithErrors.Clear();
      if (this._cachedValidationErrors != null) {
        foreach (GameObjectValidator.ValidationError error in this._cachedValidationErrors) {
          this._objectsWithErrors.Add(error.component.gameObject);
        }
      }
    }
	}
}
