using DT;
using System.Collections;
﻿using UnityEditor;
using UnityEngine;

namespace DT {
	public class DTEditor<T> : Editor where T : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public override void OnInspectorGUI() {
			if (GUI.changed) {
				EditorUtility.SetDirty(_object);
			}
		}
		
		// PRAGMA MARK - Internal
		protected T _object;
		
		protected virtual void OnEnable() {
      _object = target as T;
 		}
		
		protected virtual void OnSceneGUI() {
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
		
		protected virtual void HandleKeyDown(char character) {
			// do nothing
		}
	}
}