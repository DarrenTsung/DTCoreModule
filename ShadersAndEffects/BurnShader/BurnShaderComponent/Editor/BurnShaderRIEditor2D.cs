using DT;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEditor;
﻿using UnityEngine;

namespace DT {
	[CustomEditor(typeof(BurnShaderRIC2D))]
	public class BurnShaderRIEditor2D : RendererInstanceEditor2D<BurnShaderRIC2D> {
		// PRAGMA MARK - INTERNAL
		protected override void LayoutInspector() {
			base.LayoutInspector();
			
			// DISSOLVE
			EditorGUILayoutExtensions.Header("Dissolve Properties");
			_object.DissolveMap = (Texture2D)EditorGUILayout.ObjectField("Dissolve Map", _object.DissolveMap, typeof(Texture2D), false);
			_object.DissolveAmount = EditorGUILayout.Slider("Dissolve Amount", _object.DissolveAmount, 0.0f, 1.0f);
			
			EditorGUILayoutExtensions.Header("Burn Ramp Properties");
			_object.BurnRampTexture = (Texture2D)EditorGUILayout.ObjectField("Burn Ramp Texture", _object.BurnRampTexture, typeof(Texture2D), false);
			_object.BurnRampScale = EditorGUILayout.Slider("Burn Ramp Scale", _object.BurnRampScale, 0.0f, 1.0f);
		}
	}
}
