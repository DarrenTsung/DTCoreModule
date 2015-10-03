using DT;
using System.Collections;
﻿using UnityEditor;
using UnityEngine;

namespace DT {
	public class DTEditor<T> : Editor where T : MonoBehaviour {
		// PRAGMA MARK - INTERNAL
		protected T _object;
		
		protected void OnEnable() {
      _object = target as T;
 		}
		
		public override void OnInspectorGUI() {
			if (GUI.changed) {
				EditorUtility.SetDirty(_object);
			}
		}
	}
}