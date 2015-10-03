using DT;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEditor;
﻿using UnityEngine;

namespace DT {
	[CustomEditor(typeof(RendererInstanceComponent2D))]
	public class RendererInstanceEditor2D<T> : RendererInstanceEditor<T> where T : RendererInstanceComponent2D {
		// PRAGMA MARK - INTERNAL
		protected override void LayoutInspector() {
			base.LayoutInspector();
			
			// TEXTURE 
			_object.MainTexture = (Texture2D)EditorGUILayout.ObjectField("MainTexture", _object.MainTexture, typeof(Texture2D), false);
		}
	}
}
