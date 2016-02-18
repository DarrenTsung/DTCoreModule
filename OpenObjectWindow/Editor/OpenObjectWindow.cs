using DT;
using DT.Prefab;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
	public class OpenObjectWindow : EditorWindow {
		// PRAGMA MARK - Constants
		private const string kTextFieldControlName = "OpenObjectWindowTextField";

		private const int kMaxRowsDisplayed = 8;
		private const float kWindowWidth = 400.0f;
		private const float kWindowHeight = 40.0f;

		private const float kRowHeight = 35.0f;
		private const float kRowTitleHeight = 20.0f;
		private const float kRowSubtitleHeightPadding = -5.0f;
		private const float kRowSubtitleHeight = 20.0f;

		private const int kSubtitleMaxSoftLength = 35;
		private const int kSubtitleMaxTitleAdditiveLength = 15;

		private const float kIconEdgeSize = 17.0f;
		private const float kIconPadding = 7.0f;

		private const int kFontSize = 25;

		public static string _scriptDirectory = null;
		public static string ScriptDirectory {
			get {
				if (_scriptDirectory == null) {
					OpenObjectWindow window = ScriptableObject.CreateInstance<OpenObjectWindow>();
					MonoScript script = MonoScript.FromScriptableObject(window);
		      _scriptDirectory = Path.GetDirectoryName(AssetDatabase.GetAssetPath(script));
					ScriptableObject.DestroyImmediate(window);
				}
				return _scriptDirectory;
			}
		}


		// PRAGMA MARK - Public Interface
		[MenuItem("DarrenTsung/Open.. %t")]
		public static void ShowObjectWindow() {
      OpenObjectWindow.InitializeWindow("Open.. ");

			_openableObjectManager = new OpenableObjectManager();
      if (!Application.isPlaying) {
        _openableObjectManager.AddLoader(new OpenablePrefabObjectLoader());
        _openableObjectManager.AddLoader(new OpenableSceneObjectLoader());
      }
      _openableObjectManager.AddLoader(new SelectableGameObjectLoader());
			OpenObjectWindow.ReloadObjects();
		}

    [MenuItem("DarrenTsung/Open Command Palette.. %#m")]
		public static void ShowCommandPaletteWindow() {
      OpenObjectWindow.InitializeWindow("Command Palette.. ");

			_openableObjectManager = new OpenableObjectManager();
      _openableObjectManager.AddLoader(new OpenableMethodLoader());
			OpenObjectWindow.ReloadObjects();
		}

    public static void InitializeWindow(string title) {
			EditorWindow window = EditorWindow.GetWindow(typeof(OpenObjectWindow), utility: true, title: title, focus: true);
			window.position = new Rect(0.0f, 0.0f, kWindowWidth, kWindowHeight);
			window.CenterInMainEditorWindow();

			_selectedIndex = 0;
			_focusTrigger = true;
			_isClosing = false;
    }

		// PRAGMA MARK - Internal
		protected static string _input = "";
		protected static bool _focusTrigger = false;
		protected static bool _isClosing = false;
		protected static int _selectedIndex = 0;
		protected static IOpenableObject[] _objects = new IOpenableObject[0];
		protected static OpenableObjectManager _openableObjectManager = null;
		protected static Color _selectedBackgroundColor = ColorExtensions.HexStringToColor("#4976C2");

    private static string _parsedSearchInput = "";
    private static string[] _parsedArguments = null;

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
      this.ReparseInput();
			_selectedIndex = 0;
			OpenObjectWindow.ReloadObjects();
		}

		private static void ReloadObjects() {
			_objects = _openableObjectManager.ObjectsSortedByMatch(_parsedSearchInput);
		}

    private static void ReparseInput() {
      if (_input == null || _input.Length <= 0) {
        _parsedSearchInput = "";
        _parsedArguments = null;
        return;
      }

      string[] parameters = _input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

      _parsedSearchInput = parameters[0];

      if (parameters.Length == 1) {
        _parsedArguments = null;
      } else {
        _parsedArguments = parameters.Skip(1).ToArray();
      }
    }

		private void HandleKeyDownEvent(Event e) {
			switch (e.keyCode) {
				case KeyCode.Escape:
					this.CloseIfNotClosing();
					break;
				case KeyCode.Return:
          IOpenableObject obj = _objects[_selectedIndex];
          if (_parsedArguments != null) {
            IOpenableWithArgumentsObject castedObj;
            try {
              castedObj = (IOpenableWithArgumentsObject)obj;
              castedObj.Open(_parsedArguments);
            } catch (InvalidCastException) {
              Debug.LogWarning("Attempted to pass arguments to OpenableObject, but object does not allow arguments!");
              obj.Open();
            }
          } else {
            obj.Open();
          }
					this.CloseIfNotClosing();
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

			int currentIndex = 0;
			for (int i = 0; i < displayedAssetCount;) {
				IOpenableObject obj = _objects[currentIndex];

				currentIndex++;

				if (!obj.IsValid()) {
					continue;
				}

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
				EditorGUI.LabelField(new Rect(kWindowWidth - kIconEdgeSize - kIconPadding, topY + kIconPadding, kIconEdgeSize, kIconEdgeSize),
														 GUIContent.none,
														 textureStyle);
				i++;
			}
		}

		private void OnFocus() {
			_focusTrigger = true;
		}

		private void OnLostFocus() {
			this.CloseIfNotClosing();
		}

		protected void CloseIfNotClosing() {
			if (!_isClosing) {
				_isClosing = true;
				this.Close();
			}
		}
	}
}