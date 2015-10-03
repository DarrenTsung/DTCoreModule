using DT;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEditor;
﻿using UnityEngine;

namespace DT {
	[CustomEditor(typeof(RendererInstanceComponent))]
	public class RendererInstanceEditor<T> : DTEditor<T> where T : RendererInstanceComponent {
		// PRAGMA MARK - INTERFACE
		public override void OnInspectorGUI() {
			this.LayoutInspector();
			base.OnInspectorGUI();
		}
		
		// PRAGMA MARK - INTERNAL
		protected virtual void LayoutInspector() {
			// do nothing
		}
	}
}
