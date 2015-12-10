using DT;
using DT.Prefab;
using System.Collections;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
	public class OpenAssetEditorWindow : EditorWindow {
		// PRAGMA MARK - Constants 
		private const string kTextFieldControlName = "OpenAssetEditorWindowTextField";
		private const int kMaxRowsDisplayed = 8;
		private const float kWindowWidth = 400.0f;
		private const float kWindowHeight = 40.0f;
		private const float kRowHeight = 20.0f;
		private const int kFontSize = 25;
		
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
		
		protected static Texture2D _selectedBackgroundTexture;
		protected static Texture2D SelectedBackgroundTexture {
			get {
				if (_selectedBackgroundTexture == null) {
					_selectedBackgroundTexture = new Texture2D(1, 1);
					_selectedBackgroundTexture.hideFlags = HideFlags.DontSave;
					_selectedBackgroundTexture.SetPixel(0, 0, _selectedBackgroundColor);
					_selectedBackgroundTexture.Apply();
				}
				return _selectedBackgroundTexture;
			}
		}
		
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
			for (int i = 0; i < displayedAssetCount; i++) {
				GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
				if (i == _selectedIndex) {
					labelStyle.normal.background = OpenAssetEditorWindow.SelectedBackgroundTexture;
				}
				
				EditorGUI.LabelField(new Rect(0.0f, kWindowHeight + kRowHeight * i, kWindowWidth, kRowHeight), _objects[i].DisplayName, labelStyle);
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