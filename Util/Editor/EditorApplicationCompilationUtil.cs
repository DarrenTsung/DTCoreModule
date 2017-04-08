using System;
using UnityEditor;
using UnityEngine;

namespace DT {
	[InitializeOnLoad]
	public static class EditorApplicationCompilationUtil {
		public static event Action StartedCompiling = delegate { };
		public static event Action FinishedCompiling = delegate { };

		static EditorApplicationCompilationUtil() {
			EditorApplication.update += OnEditorUpdate;
		}


		private static bool StoredCompilingState_ {
			get { return EditorPrefs.GetBool("EditorApplicationCompilationUtil::StoredCompilingState"); }
			set { EditorPrefs.SetBool("EditorApplicationCompilationUtil::StoredCompilingState", value); }
		}

		private static void OnEditorUpdate() {
			if (EditorApplication.isCompiling && StoredCompilingState_ == false) {
				StoredCompilingState_ = true;
				StartedCompiling.Invoke();
			}

			if (!EditorApplication.isCompiling && StoredCompilingState_ == true) {
				StoredCompilingState_ = false;
				FinishedCompiling.Invoke();
			}
		}
	}
}