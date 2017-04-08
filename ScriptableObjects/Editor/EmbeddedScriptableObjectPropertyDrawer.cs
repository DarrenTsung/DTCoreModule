using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
	[CustomPropertyDrawer(typeof(EmbeddedScriptableObject), true)]
	public class EmbeddedScriptableObjectPropertyDrawer : PropertyDrawer {
		// PRAGMA MARK - Public Interface
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			Editor.CreateCachedEditor(property.objectReferenceValue, null, ref editor_);

			property_ = property;

			Color oldColor = GUI.color;
			GUI.color = Color.Lerp(Color.white, Color.yellow, 0.25f);

			EditorGUI.PropertyField(position, property, label);

			GUI.color = oldColor;

			if (editor_ != null) {
				EmbeddedScriptableObjectGUI.IncreaseIndent();

				editor_.OnInspectorGUI();

				EmbeddedScriptableObjectGUI.DecreaseIndent();
			}

			// handle click on property
			Event clickEvent = Event.current;

			bool rightClick = clickEvent.type == EventType.MouseDown && clickEvent.button == 1;
			bool insidePosition = position.Contains(clickEvent.mousePosition);

			if (rightClick && insidePosition) {
				clickEvent.Use();

				EditorUtility.DisplayCustomMenu(new Rect(clickEvent.mousePosition, Vector2.zero),
				  FieldImplementationTypes_.Select(t => new GUIContent(t.Name)).ToArray(),
				  selected: -1,
				  callback: HandleCreateAssetClick,
				  userData: null);
			}
		}


		// PRAGMA MARK - Internal
		private Editor editor_;
		private SerializedProperty property_;

		private Type[] fieldImplementationTypes_ = null;
		private Type[] FieldImplementationTypes_ {
			get {
				if (fieldImplementationTypes_ == null) {
					Type type = this.fieldInfo.FieldType;
					if (type.IsGenericType) {
						type = type.GetGenericArguments()[0];
					}

					fieldImplementationTypes_ = TypeUtil.GetImplementationTypes(type);
				}

				return fieldImplementationTypes_;
			}
		}

		private void HandleCreateAssetClick(object userData, string[] options, int selected) {
			CreateAsset(FieldImplementationTypes_[selected]);
		}

		private void CreateAsset(Type type) {
			UnityEngine.Object oldObject = property_.objectReferenceValue;
			UnityEngine.Object assetClickedOn = Selection.activeObject;

			var asset = ScriptableObject.CreateInstance(type);
			asset.name = type.Name;

			if (oldObject != null) {
				if (!EditorUtility.DisplayDialog("Overwrite?", "This will overwrite the object previously in the field. This cannot be undone.", "Continue", "Cancel")) {
					return;
				}

				ObjectUtil.DestroyImmediateRecursive(oldObject, allowDestroyingAssets: true);
			}

			AssetDatabase.AddObjectToAsset(asset, assetClickedOn);
			AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(asset));
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			Selection.activeObject = asset;

			property_.objectReferenceValue = asset;
			property_.serializedObject.ApplyModifiedProperties();
		}
	}
}