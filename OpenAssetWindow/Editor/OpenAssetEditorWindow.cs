using DT;
using DT.Prefab;
using System;
using System.Collections;
using System.IO;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
	public class OpenAssetEditorWindow : EditorWindow {
		// PRAGMA MARK - Constants 
		public static string EditorWindowScriptPath;
		private const string kTextFieldControlName = "OpenAssetEditorWindowTextField";
		
		private const int kMaxRowsDisplayed = 8;
		private const float kWindowWidth = 400.0f;
		private const float kWindowHeight = 40.0f;
		
		private const float kRowHeight = 35.0f;
		private const float kRowTitleHeight = 20.0f;
		private const float kRowSubtitleHeightPadding = -5.0f;
		private const float kRowSubtitleHeight = 20.0f;
		
		private const int kSubtitleMaxSoftLength = 35;
		private const int kSubtitleMaxTitleAdditiveLength = 15;
		
		private const float kIconEdgeSize = 20.0f;
		private const float kIconPadding = 5.0f;
		
		private const int kFontSize = 25;
		
		static OpenAssetEditorWindow() {
			OpenAssetEditorWindow window = ScriptableObject.CreateInstance<OpenAssetEditorWindow>();
			MonoScript script = MonoScript.FromScriptableObject(window);
      OpenAssetEditorWindow.EditorWindowScriptPath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(script));
			ScriptableObject.DestroyImmediate(window);
		}
		
		
		// PRAGMA MARK - Public Interface
		[MenuItem("DarrenTsung/Open Asset.. %t")]
		public static void ShowWindow() {
			EditorWindow window = EditorWindow.GetWindow(typeof(OpenAssetEditorWindow), utility: true, title: "Open..", focus: true);
			window.position = new Rect(0.0f, 0.0f, kWindowWidth, kWindowHeight);
			window.CenterInMainEditorWindow();
			
			_selectedIndex = 0;
			_focusTrigger = true;
			
			_openableObjectManager = new OpenableObjectManager();
			OpenAssetEditorWindow.ReloadObjects();
		}
		
		// PRAGMA MARK - Internal
		protected static string _input = "";
		protected static bool _focusTrigger = false;
		protected static int _selectedIndex = 0;
		protected static IOpenableObject[] _objects = new IOpenableObject[0];
		protected static OpenableObjectManager _openableObjectManager = null;
		protected static Color _selectedBackgroundColor = ColorExtensions.HexStringToColor("#4976C2");
		
		protected void OnGUI() {
			if (_focusTrigger) {
				_focusTrigger = false;
				EditorGUI.FocusTextInControl(kTextFieldControlName);
			}
			
			Event e = Event.current;
			switch (e.type) {
				case EventType.KeyDown:
					this.HandleKeyDownEvent(e);
					break;
				default:
					break;
			}		
			
			if (_objects.Length > 0) {
				_selectedIndex = MathUtil.Wrap(_selectedIndex, 0, Mathf.Min(_objects.Length, kMaxRowsDisplayed));
			} else {
				_selectedIndex = 0;
			}
			
			GUIStyle textFieldStyle = new GUIStyle(GUI.skin.textField);
			textFieldStyle.fontSize = kFontSize;
			
			GUI.SetNextControlName(kTextFieldControlName);
			string updatedInput = EditorGUI.TextField(new Rect(0.0f, 0.0f, kWindowWidth, kWindowHeight), _input, textFieldStyle);
			if (updatedInput != _input) {
				_input = updatedInput;
				this.HandleInputUpdated();
			}
			
			int displayedAssetCount = Mathf.Min(_objects.Length, kMaxRowsDisplayed);
			this.DrawDropDown(displayedAssetCount);
			
			this.position = new Rect(this.position.x, this.position.y, this.position.width, kWindowHeight + displayedAssetCount * kRowHeight);
		}
		
		private void HandleInputUpdated() {
			_selectedIndex = 0;
			OpenAssetEditorWindow.ReloadObjects();
		}
		
		private static void ReloadObjects() {
			_objects = _openableObjectManager.ObjectsSortedByMatch(_input);
		}
		
		private void HandleKeyDownEvent(Event e) {
			switch (e.keyCode) {
				case KeyCode.Escape:
					this.Close();
					break;
				case KeyCode.Return:
					_objects[_selectedIndex].Open();
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
		
		private void DrawDropDown(int displayedAssetCount) {
			GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
			titleStyle.fontStyle = FontStyle.Bold;
			
			GUIStyle subtitleStyle = new GUIStyle(GUI.skin.label);
			subtitleStyle.fontSize = (int)(subtitleStyle.fontSize * 1.2f);
			
			for (int i = 0; i < displayedAssetCount; i++) {
				IOpenableObject obj = _objects[i];
				
				float topY = kWindowHeight + kRowHeight * i;
				
				if (i == _selectedIndex) {
					EditorGUI.DrawRect(new Rect(0.0f, topY, kWindowWidth, kRowHeight), _selectedBackgroundColor);
				}
				
				string title = obj.DisplayTitle;
				string subtitle = obj.DisplayDetailText;
				
				int subtitleMaxLength = Math.Min(kSubtitleMaxSoftLength + title.Length, kSubtitleMaxSoftLength + kSubtitleMaxTitleAdditiveLength);
				if (subtitle.Length > subtitleMaxLength + 2) {
					subtitle = ".." + subtitle.Substring(subtitle.Length - subtitleMaxLength);
				}
				
				EditorGUI.LabelField(new Rect(0.0f, topY, kWindowWidth, kRowTitleHeight), title, titleStyle);
				EditorGUI.LabelField(new Rect(0.0f, topY + kRowTitleHeight + kRowSubtitleHeightPadding, kWindowWidth, kRowSubtitleHeight), subtitle, subtitleStyle);
				
				GUIStyle textureStyle = new GUIStyle();
				textureStyle.normal.background = obj.DisplayIcon;
				EditorGUI.LabelField(new Rect(kWindowWidth - kIconEdgeSize - kIconPadding, 
																			topY + kIconPadding, 
																			kIconEdgeSize, 
																			kIconEdgeSize), 
														 GUIContent.none,
														 textureStyle);
			}
		}
		
		private void OnFocus() {
			_focusTrigger = true;
		}
		
		private void OnLostFocus() {
			this.Close();
		}
	}
}