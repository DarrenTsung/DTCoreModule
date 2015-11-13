using DT;
using System.Collections;
using UnityEditor;
﻿using UnityEngine;

public class OpenAssetEditorWindow : EditorWindow {
	// PRAGMA MARK - Constants 
	private const string kTextFieldControlName = "OpenAssetEditorWindowTextField";
	private const int kMaxRowsDisplayed = 8;
	private const float kWindowWidth = 400.0f;
	private const float kWindowHeight = 40.0f;
	private const float kRowHeight = 20.0f;
	private const int kFontSize = 25;
	
	// PRAGMA MARK - Interface
	[MenuItem("DarrenTsung/Open Asset.. %t")]
	public static void ShowWindow() {
		EditorWindow window = EditorWindow.GetWindow(typeof(OpenAssetEditorWindow), utility: true, title: "Open File", focus: true);
		window.position = new Rect(0.0f, 0.0f, kWindowWidth, kWindowHeight);
		window.CenterInMainEditorWindow();
		
		_selectedIndex = 0;
		_justFocused = true;
	}
	
	// PRAGMA MARK - Internal
	protected static Color selectedBackgroundColor = ColorExtensions.HexStringToColor("#4976C2");
	protected static string _assetName = "";
	protected static bool _justFocused = false;
	protected static int _selectedIndex = 0;
	
	protected void OnGUI() {
		if (_justFocused) {
			_justFocused = false;
			EditorGUI.FocusTextInControl(kTextFieldControlName);
		}
		
		string[] guids = AssetDatabase.FindAssets(_assetName + " t:Prefab t:Scene");
		
		Event e = Event.current;
		switch (e.type) {
			case EventType.KeyDown:
				this.HandleKeyDownEvent(e, guids);
				break;
			default:
				break;
		}		
		
		if (guids.Length > 0) {
			_selectedIndex = MathUtil.Wrap(_selectedIndex, 0, Mathf.Min(guids.Length, kMaxRowsDisplayed));
		} else {
			_selectedIndex = 0;
		}
		
		GUIStyle textFieldStyle = new GUIStyle(GUI.skin.textField);
		textFieldStyle.fontSize = kFontSize;
		
		GUI.SetNextControlName(kTextFieldControlName);
		string updatedName = EditorGUI.TextField(new Rect(0.0f, 0.0f, kWindowWidth, kWindowHeight), _assetName, textFieldStyle);
		if (updatedName != _assetName) {
			_assetName = updatedName;
			_selectedIndex = 0;
		}
		
		int displayedAssetCount = 0;
		if (!string.IsNullOrEmpty(_assetName)) {
			displayedAssetCount = Mathf.Min(guids.Length, kMaxRowsDisplayed);
			this.DrawDropDown(guids, displayedAssetCount);
		}
		
		this.position = new Rect(this.position.x, this.position.y, this.position.width, kWindowHeight + displayedAssetCount * kRowHeight);
	}
	
	private void HandleKeyDownEvent(Event e, string[] guids) {
		switch (e.keyCode) {
			case KeyCode.Escape:
				this.Close();
				break;
			case KeyCode.Return:
				if (guids.Length > 0) {
					string path = AssetDatabase.GUIDToAssetPath(guids[_selectedIndex]);
					if (path.Contains(".unity")) {
						if (EditorApplication.isSceneDirty) {
							if (EditorApplication.SaveCurrentSceneIfUserWantsTo()) {
								EditorApplication.OpenScene(path);
							}
						} else {
							EditorApplication.OpenScene(path);
						}
					} else if (path.Contains(".prefab")) {
						// TODO (darren): open prefab sandbox here
					}
				}
				this.Close();
				break;
			case KeyCode.DownArrow:
				_selectedIndex++;
				e.Use();
				break;
			case KeyCode.UpArrow:
				_selectedIndex--;
				e.Use();
				break;
			default:
				break;
		}
	}
	
	private static Texture2D _selectedBackgroundTexture;
	private static Texture2D SelectedBackgroundTexture {
		get {
			if (_selectedBackgroundTexture == null) {
				_selectedBackgroundTexture = new Texture2D(1, 1);
				_selectedBackgroundTexture.hideFlags = HideFlags.DontSave;
				_selectedBackgroundTexture.SetPixel(0, 0, selectedBackgroundColor);
				_selectedBackgroundTexture.Apply();
			}
			return _selectedBackgroundTexture;
		}
	}
	
	private void DrawDropDown(string[] guids, int displayedAssetCount) {
		for (int i = 0; i < displayedAssetCount; i++) {
			GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
			if (i == _selectedIndex) {
				labelStyle.normal.background = OpenAssetEditorWindow.SelectedBackgroundTexture;
			}
			
			string prefabName = System.IO.Path.GetFileName(AssetDatabase.GUIDToAssetPath(guids[i]));
			EditorGUI.LabelField(new Rect(0.0f, kWindowHeight + kRowHeight * i, kWindowWidth, kRowHeight), prefabName, labelStyle);
		}
	}
	
	private void OnFocus() {
		_justFocused = true;
	}
	
	private void OnLostFocus() {
		this.Close();
	}
}
