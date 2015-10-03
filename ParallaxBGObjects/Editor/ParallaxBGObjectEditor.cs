using DT;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEditor;
﻿using UnityEngine;

namespace DT.ParallaxBGObjects {
	[CustomEditor(typeof(ParallaxBGObject))]
	public class ParallaxBGObjectEditor : Editor {
		// PRAGMA MARK - INTERNAL
		// protected AutoSnap _autoSnapInstance = AutoSnap.Instance();
		protected ParallaxBGObject obj;
		
		private void OnEnable() {
      obj = target as ParallaxBGObject;
 		}
		
		protected void OnSceneGUI() {
			this.ListenForEvents();
		}
		
		protected void ListenForEvents() {
			Event e = Event.current;
			switch (e.type) {
				case EventType.KeyDown:
					this.HandleKeyDown(e.character);
					break;
			}
		}
		
		protected void HandleKeyDown(char character) {
			switch (character) {
				case 'a':
					break;
				case 'd':
					break;
			}
		}
		
		public override void OnInspectorGUI() {
			// DEPTH
			obj.Depth = EditorGUILayout.IntSlider("Depth", obj.Depth, 0, obj.MaxDepth);
			obj.MaxDepth = EditorGUILayout.IntField("Max Depth", obj.MaxDepth);
			
			float relativeDepth = obj.RelativeDepth;
			EditorGUILayout.LabelField("Relative Depth (Used for calculations): " + relativeDepth);
			
			// SORTING
			EditorGUILayoutExtensions.Header("Sorting");
			obj.DepthOffset = EditorGUILayout.IntField("Depth Offset", obj.DepthOffset);
			EditorGUILayout.LabelField("Computed Sorting Order: " + obj.SortingOrder);
			
			// PROPERTIES
			EditorGUILayoutExtensions.Header("Properties");
			
			GUIContent colorBlendContent = new GUIContent("Color Blend Scale", "Lerp(SpriteColor, BackgroundColor, RelativeDepth * ColorBlendScale)");
			obj.ColorBlendScale = EditorGUILayout.Slider(colorBlendContent, obj.ColorBlendScale, 0.0f, 1.0f);
			
			float backgroundPercentage = (relativeDepth * obj.ColorBlendScale);
			float originalSpritePercentage = 1.0f - backgroundPercentage;
			EditorGUILayout.LabelField("Color = " + originalSpritePercentage.ToPercentageString() + " Original Sprite  |  " + backgroundPercentage.ToPercentageString() + " Background");
			EditorGUILayout.Space();
			
			GUIContent sizeReductionContent = new GUIContent("Size Reduction Scale", "Scale = 1.0f - (SizeReductionScale * RelativeDepth)");
			obj.SizeReductionScale = EditorGUILayout.Slider(sizeReductionContent, obj.SizeReductionScale, 0.0f, 1.0f);
			
			float computedSize = 1.0f - (relativeDepth * obj.SizeReductionScale);
			EditorGUILayout.LabelField("Size = " + computedSize.ToPercentageString());
			
			if (GUI.changed) {
				EditorUtility.SetDirty(obj);
			}
		}
		
		protected ParallaxBGObject Object() {
			return (ParallaxBGObject)target;
		}
	}
}