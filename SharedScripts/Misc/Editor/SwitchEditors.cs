using UnityEngine;
using UnityEditor;

namespace DT {
	public class SwitchEditorsMenu {
		private static void Set(string name, string path) {
			EditorPrefs.SetString("kScriptsDefaultApp", path);
			Debug.Log("Script editor set to " + name);
		}
		
		[MenuItem("DarrenTsung/Switch Editors/Set to Atom #%a")]
		public static void Vim() {
			Set("Atom", "/Applications/Atom.app");
		}
		
		[MenuItem("DarrenTsung/Switch Editors/Set to MonoDevelop #%m")]
		public static void MonoDevelop() {
			Set("MonoDevelop (built-in)", "");
		}
		
		[MenuItem("DarrenTsung/Switch Editors/Show setting")]
		public static void Show() {
			Debug.Log("Script editor: " + EditorPrefs.GetString("kScriptsDefaultApp"));
		}
	}
}