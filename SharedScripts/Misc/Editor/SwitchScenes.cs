using System.IO;
using UnityEditor;
using UnityEngine;
 
namespace DT {
	/// <summary>
	/// SwitchSceneWindow (http://wiki.unity3d.com/index.php/SceneViewWindow)
	/// </summary>
	public class SwitchSceneWindow : EditorWindow {
		/// <summary>
		/// Tracks scroll position.
		/// </summary>
		private Vector2 scrollPos;
		
		/// <summary>
		/// Initialize window state.
		/// </summary>
		[MenuItem("DarrenTsung/Switch Scenes %t")]
		internal static void Init() {
			// EditorWindow.GetWindow() will return the open instance of the specified window or create a new
			// instance if it can't find one. The second parameter is a flag for creating the window as a
			// Utility window; Utility windows cannot be docked like the Scene and Game view windows.
			var window = GetWindow<SwitchSceneWindow>(false, "Switch Scenes View");
			window.maxSize = new Vector2(200, 125);
		}
		
		/// <summary>
		/// Called on GUI events.
		/// </summary>
		internal void OnGUI() {
			EditorGUILayout.BeginVertical();
			this.scrollPos = EditorGUILayout.BeginScrollView(this.scrollPos, false, false);
			
			GUILayout.Label("Scenes In Build", EditorStyles.boldLabel);
			for (var i = 0; i < EditorBuildSettings.scenes.Length; i++) {
				var scene = EditorBuildSettings.scenes[i];
				if (scene.enabled) {
					var sceneName = Path.GetFileNameWithoutExtension(scene.path);
					var pressed = GUILayout.Button(i + ": " + sceneName, new GUIStyle(GUI.skin.GetStyle("Button")) { alignment = TextAnchor.MiddleLeft });
					if (pressed) {
						if (EditorApplication.SaveCurrentSceneIfUserWantsTo()) {
							EditorApplication.OpenScene(scene.path);
						}
					}
				}
			}
			
			EditorGUILayout.EndScrollView();
			EditorGUILayout.EndVertical();
		}
	}
}