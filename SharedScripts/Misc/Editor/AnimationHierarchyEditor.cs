using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace DT {
	/// All credit goes to
	/// https://github.com/s-m-k/Unity-Animation-Hierarchy-Editor/blob/master/AnimationHierarchyEditor.cs
	/// I find this very useful so I'm sticking it in my shared scripts
	public class AnimationHierarchyEditor : EditorWindow {
		private static int columnWidth_ = 300;

		private Animator animatorObject_;
		private List<AnimationClip> animationClips_;
		private ArrayList pathsKeys_;
		private Hashtable paths_;

		private Dictionary<string, string> tempPathOverrides_;

		private Vector2 scrollPos_ = Vector2.zero;

		[MenuItem("DarrenTsung/Animation Hierarchy Editor")]
		private static void ShowWindow() {
			EditorWindow.GetWindow<AnimationHierarchyEditor>();
		}


		public AnimationHierarchyEditor() {
			animationClips_ = new List<AnimationClip>();
			tempPathOverrides_ = new Dictionary<string, string>();
		}

		private void OnSelectionChange() {
			if (Selection.objects.Length > 1) {
				animationClips_.Clear();
				foreach (Object o in Selection.objects) {
					if (o is AnimationClip) {
						animationClips_.Add((AnimationClip)o);
					}
				}
			} else if (Selection.activeObject is AnimationClip) {
				animationClips_.Clear();
				animationClips_.Add((AnimationClip)Selection.activeObject);
				FillModel();
			} else {
				animationClips_.Clear();
			}

			Repaint();
		}

		private string sOriginalRoot_ = "Root";
		private string sNewRoot_ = "SomeNewObject/Root";

		private void OnGUI() {
			if (Event.current.type == EventType.ValidateCommand) {
				switch (Event.current.commandName) {
					case "UndoRedoPerformed":
						FillModel();
						break;
				}
			}

			if (animationClips_.Count > 0) {
				scrollPos_ = GUILayout.BeginScrollView(scrollPos_, GUIStyle.none);

				EditorGUILayout.BeginHorizontal();
				GUILayout.Label("Referenced Animator (Root):", GUILayout.Width(columnWidth_));

				animatorObject_ = ((Animator)EditorGUILayout.ObjectField(
					animatorObject_,
					typeof(Animator),
					true,
					GUILayout.Width(columnWidth_))
								  );


				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				GUILayout.Label("Animation Clip:", GUILayout.Width(columnWidth_));

				if (animationClips_.Count == 1) {
					animationClips_[0] = ((AnimationClip)EditorGUILayout.ObjectField(
						animationClips_[0],
						typeof(AnimationClip),
						true,
						GUILayout.Width(columnWidth_))
									  );
				} else {
					GUILayout.Label("Multiple Anim Clips: " + animationClips_.Count, GUILayout.Width(columnWidth_));
				}
				EditorGUILayout.EndHorizontal();

				GUILayout.Space(20);

				EditorGUILayout.BeginHorizontal();

				sOriginalRoot_ = EditorGUILayout.TextField(sOriginalRoot_, GUILayout.Width(columnWidth_));
				sNewRoot_ = EditorGUILayout.TextField(sNewRoot_, GUILayout.Width(columnWidth_));
				if (GUILayout.Button("Replace Root")) {
					Debug.Log("O: " + sOriginalRoot_ + " N: " + sNewRoot_);
					ReplaceRoot(sOriginalRoot_, sNewRoot_);
				}

				EditorGUILayout.EndHorizontal();

				EditorGUILayout.BeginHorizontal();
				GUILayout.Label("Reference path:", GUILayout.Width(columnWidth_));
				GUILayout.Label("Animated properties:", GUILayout.Width(columnWidth_ * 0.5f));
				GUILayout.Label("(Count)", GUILayout.Width(60));
				GUILayout.Label("Object:", GUILayout.Width(columnWidth_));
				EditorGUILayout.EndHorizontal();

				if (paths_ != null) {
					foreach (string path in pathsKeys_) {
						GUICreatePathItem(path);
					}
				}

				GUILayout.Space(40);
				GUILayout.EndScrollView();
			} else {
				GUILayout.Label("Please select an Animation Clip");
			}
		}


		private void GUICreatePathItem(string path) {
			string newPath = path;
			GameObject obj = FindObjectInRoot(path);
			GameObject newObj;
			ArrayList properties = (ArrayList)paths_[path];

			string pathOverride = path;

			if (tempPathOverrides_.ContainsKey(path)) {
				pathOverride = tempPathOverrides_[path];
			}

			EditorGUILayout.BeginHorizontal();

			pathOverride = EditorGUILayout.TextField(pathOverride, GUILayout.Width(columnWidth_));
			if (pathOverride != path) {
				tempPathOverrides_[path] = pathOverride;
			}

			if (GUILayout.Button("Change", GUILayout.Width(60))) {
				newPath = pathOverride;
				tempPathOverrides_.Remove(path);
			}

			EditorGUILayout.LabelField(
				properties != null ? properties.Count.ToString() : "0",
				GUILayout.Width(60)
				);

			Color standardColor = GUI.color;

			if (obj != null) {
				GUI.color = Color.green;
			} else {
				GUI.color = Color.red;
			}

			newObj = (GameObject)EditorGUILayout.ObjectField(
				obj,
				typeof(GameObject),
				true,
				GUILayout.Width(columnWidth_)
				);

			GUI.color = standardColor;

			EditorGUILayout.EndHorizontal();

			try {
				if (obj != newObj) {
					UpdatePath(path, ChildPath(newObj));
				}

				if (newPath != path) {
					UpdatePath(path, newPath);
				}
			} catch (UnityException ex) {
				Debug.LogError(ex.Message);
			}
		}

		private void OnInspectorUpdate() {
			Repaint();
		}

		private void FillModel() {
			paths_ = new Hashtable();
			pathsKeys_ = new ArrayList();

			foreach (AnimationClip animationClip in animationClips_) {
				FillModelWithCurves(AnimationUtility.GetCurveBindings(animationClip));
				FillModelWithCurves(AnimationUtility.GetObjectReferenceCurveBindings(animationClip));
			}
		}

		private void FillModelWithCurves(EditorCurveBinding[] curves) {
			foreach (EditorCurveBinding curveData in curves) {
				string key = curveData.path;

				if (paths_.ContainsKey(key)) {
					((ArrayList)paths_[key]).Add(curveData);
				} else {
					ArrayList newProperties = new ArrayList();
					newProperties.Add(curveData);
					paths_.Add(key, newProperties);
					pathsKeys_.Add(key);
				}
			}
		}

		private string sReplacementOldRoot_;
		private string sReplacementNewRoot_;


		private void ReplaceRoot(string oldRoot, string newRoot) {
			float fProgress = 0.0f;
			sReplacementOldRoot_ = oldRoot;
			sReplacementNewRoot_ = newRoot;

			AssetDatabase.StartAssetEditing();

			for (int iCurrentClip = 0; iCurrentClip < animationClips_.Count; iCurrentClip++) {
				AnimationClip animationClip = animationClips_[iCurrentClip];
				Undo.RecordObject(animationClip, "Animation Hierarchy Root Change");

				for (int iCurrentPath = 0; iCurrentPath < pathsKeys_.Count; iCurrentPath++) {
					string path = pathsKeys_[iCurrentPath] as string;
					ArrayList curves = (ArrayList)paths_[path];

					for (int i = 0; i < curves.Count; i++) {
						EditorCurveBinding binding = (EditorCurveBinding)curves[i];

						if (path.Contains(sReplacementOldRoot_)) {
							if (!path.Contains(sReplacementNewRoot_)) {
								string sNewPath = Regex.Replace(path, "^" + sReplacementOldRoot_, sReplacementNewRoot_);

								AnimationCurve curve = AnimationUtility.GetEditorCurve(animationClip, binding);
								if (curve != null) {
									AnimationUtility.SetEditorCurve(animationClip, binding, null);
									binding.path = sNewPath;
									AnimationUtility.SetEditorCurve(animationClip, binding, curve);
								} else {
									ObjectReferenceKeyframe[] objectReferenceCurve = AnimationUtility.GetObjectReferenceCurve(animationClip, binding);
									AnimationUtility.SetObjectReferenceCurve(animationClip, binding, null);
									binding.path = sNewPath;
									AnimationUtility.SetObjectReferenceCurve(animationClip, binding, objectReferenceCurve);
								}
							}
						}
					}

					// Update the progress meter
					float fChunk = 1f / animationClips_.Count;
					fProgress = (iCurrentClip * fChunk) + fChunk * ((float)iCurrentPath / (float)pathsKeys_.Count);

					EditorUtility.DisplayProgressBar(
						"Animation Hierarchy Progress",
						"How far along the animation editing has progressed.",
						fProgress);
				}
			}
			AssetDatabase.StopAssetEditing();
			EditorUtility.ClearProgressBar();

			FillModel();
			Repaint();
		}

		private void UpdatePath(string oldPath, string newPath) {
			if (paths_[newPath] != null) {
				throw new UnityException("Path " + newPath + " already exists in that animation!");
			}
			AssetDatabase.StartAssetEditing();
			for (int iCurrentClip = 0; iCurrentClip < animationClips_.Count; iCurrentClip++) {
				AnimationClip animationClip = animationClips_[iCurrentClip];
				Undo.RecordObject(animationClip, "Animation Hierarchy Change");

				//recreating all curves one by one
				//to maintain proper order in the editor -
				//slower than just removing old curve
				//and adding a corrected one, but it's more
				//user-friendly
				for (int iCurrentPath = 0; iCurrentPath < pathsKeys_.Count; iCurrentPath++) {
					string path = pathsKeys_[iCurrentPath] as string;
					ArrayList curves = (ArrayList)paths_[path];

					for (int i = 0; i < curves.Count; i++) {
						EditorCurveBinding binding = (EditorCurveBinding)curves[i];
						AnimationCurve curve = AnimationUtility.GetEditorCurve(animationClip, binding);
						ObjectReferenceKeyframe[] objectReferenceCurve = AnimationUtility.GetObjectReferenceCurve(animationClip, binding);


						if (curve != null) {
							AnimationUtility.SetEditorCurve(animationClip, binding, null);
						} else {
							AnimationUtility.SetObjectReferenceCurve(animationClip, binding, null);
						}

						if (path == oldPath) {
							binding.path = newPath;
						}

						if (curve != null) {
							AnimationUtility.SetEditorCurve(animationClip, binding, curve);
						} else {
							AnimationUtility.SetObjectReferenceCurve(animationClip, binding, objectReferenceCurve);
						}

						float fChunk = 1f / animationClips_.Count;
						float fProgress = (iCurrentClip * fChunk) + fChunk * ((float)iCurrentPath / (float)pathsKeys_.Count);

						EditorUtility.DisplayProgressBar(
							"Animation Hierarchy Progress",
							"How far along the animation editing has progressed.",
							fProgress);
					}
				}
			}
			AssetDatabase.StopAssetEditing();
			EditorUtility.ClearProgressBar();
			FillModel();
			Repaint();
		}

		private GameObject FindObjectInRoot(string path) {
			if (animatorObject_ == null) {
				return null;
			}

			Transform child = animatorObject_.transform.Find(path);

			if (child != null) {
				return child.gameObject;
			} else {
				return null;
			}
		}

		private string ChildPath(GameObject obj, bool sep = false) {
			if (animatorObject_ == null) {
				throw new UnityException("Please assign Referenced Animator (Root) first!");
			}

			if (obj == animatorObject_.gameObject) {
				return "";
			} else {
				if (obj.transform.parent == null) {
					throw new UnityException("Object must belong to " + animatorObject_.ToString() + "!");
				} else {
					return ChildPath(obj.transform.parent.gameObject, true) + obj.name + (sep ? "/" : "");
				}
			}
		}
	}
}