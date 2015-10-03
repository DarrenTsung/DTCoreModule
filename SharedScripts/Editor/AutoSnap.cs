using UnityEngine; 
using UnityEditor;

namespace DT {
	public class AutoSnap {
		static AutoSnap _instance;
		public static AutoSnap Instance() {
			if (_instance == null) {
				_instance = new AutoSnap();
			}
			return _instance;
		}
		
		private const string SHOULD_SNAP_KEY        = "AutoSnap_doSnapKey";
		private const string SHOULD_ROTATE_KEY      = "AutoSnap_doRotateSnapKey";
		private const string SNAP_VALUE_X_KEY       = "AutoSnap_snapValueXKey";
		private const string SNAP_VALUE_Y_KEY       = "AutoSnap_snapValueYKey";
		private const string SNAP_VALUE_Z_KEY       = "AutoSnap_snapValueZKey";
		private const string SNAP_ROTATE_VALUE_KEY  = "AutoSnap_snapRotateValueKey";
		
		public bool ShouldSnap = true;
		public bool ShouldRotateSnap = true;
		public float SnapValueX = 1.0f;
		public float SnapValueY = 1.0f;
		public float SnapValueZ = 1.0f;
		public float SnapRotateValue = 1.0f;
		
		public AutoSnap() {
			this.LoadPreferences();
		}
		
		public Vector3 SnapToValues(Vector3 input) {
			if (!this.ShouldSnap) {
				return input;
			}
			
			return input.SetXYZ(this.Round(input.x, this.SnapValueX), 
													this.Round(input.y, this.SnapValueY), 
													this.Round(input.z, this.SnapValueZ));
		}
		
		public Vector3 SnapRotation(Vector3 input) {
			if (!this.ShouldRotateSnap) {
				return input;
			}
			
			return input.SetXYZ(this.Round(input.x, this.SnapRotateValue), 
													this.Round(input.y, this.SnapRotateValue), 
													this.Round(input.z, this.SnapRotateValue));
		}
		
		protected float Round(float input, float snapValue) {
			return snapValue * Mathf.Round((input / snapValue));
		}

		protected void LoadPreferences() {
			if (EditorPrefs.HasKey(SHOULD_SNAP_KEY)) {
				this.ShouldSnap = EditorPrefs.GetBool(SHOULD_SNAP_KEY);
			}
			if (EditorPrefs.HasKey(SHOULD_ROTATE_KEY)) {
				this.ShouldRotateSnap = EditorPrefs.GetBool(SHOULD_ROTATE_KEY);
			}
			if (EditorPrefs.HasKey(SNAP_VALUE_X_KEY)) {
				this.SnapValueX = EditorPrefs.GetFloat(SNAP_VALUE_X_KEY);
			}
			if (EditorPrefs.HasKey(SNAP_VALUE_Y_KEY)) {
				this.SnapValueY = EditorPrefs.GetFloat(SNAP_VALUE_Y_KEY);
			}
			if (EditorPrefs.HasKey(SNAP_VALUE_Z_KEY)) {
				this.SnapValueZ = EditorPrefs.GetFloat(SNAP_VALUE_Z_KEY);
			}
			if (EditorPrefs.HasKey(SNAP_ROTATE_VALUE_KEY)) {
				this.SnapRotateValue = EditorPrefs.GetFloat(SNAP_ROTATE_VALUE_KEY);
			}
		}

		public void SavePreferences() {
			EditorPrefs.SetBool(SHOULD_SNAP_KEY, this.ShouldSnap);
			EditorPrefs.SetBool(SHOULD_ROTATE_KEY, this.ShouldRotateSnap);
			EditorPrefs.SetFloat(SNAP_VALUE_X_KEY, this.SnapValueX);
			EditorPrefs.SetFloat(SNAP_VALUE_Y_KEY, this.SnapValueY);
			EditorPrefs.SetFloat(SNAP_VALUE_Z_KEY, this.SnapValueZ);
			EditorPrefs.SetFloat(SNAP_ROTATE_VALUE_KEY, this.SnapRotateValue);
		}
	}

	public class AutoSnapEditorWindow : EditorWindow {
		private Vector3 prevPosition;
		private Vector3 prevRotation;
		
		protected AutoSnap _autoSnapInstance = AutoSnap.Instance();

		[MenuItem("Edit/Auto Snap %_l")]
		static void Init() {
			AutoSnapEditorWindow window = (AutoSnapEditorWindow)EditorWindow.GetWindow(typeof(AutoSnapEditorWindow));
			window.maxSize = new Vector2(200, 125);
		}

		public void OnGUI() {
			_autoSnapInstance.ShouldSnap = EditorGUILayout.Toggle("Auto Snap", _autoSnapInstance.ShouldSnap);
			_autoSnapInstance.ShouldRotateSnap = EditorGUILayout.Toggle("Auto Snap Rotation", _autoSnapInstance.ShouldRotateSnap);
			_autoSnapInstance.SnapValueX = EditorGUILayout.FloatField("Snap X Value", _autoSnapInstance.SnapValueX);
			_autoSnapInstance.SnapValueY = EditorGUILayout.FloatField("Snap Y Value", _autoSnapInstance.SnapValueY);
			_autoSnapInstance.SnapValueZ = EditorGUILayout.FloatField("Snap Z Value", _autoSnapInstance.SnapValueZ);
			_autoSnapInstance.SnapRotateValue = EditorGUILayout.FloatField("Rotation Snap Value", _autoSnapInstance.SnapRotateValue);
			
			_autoSnapInstance.SavePreferences();
		}

		public void Update() {
			if (!EditorApplication.isPlaying
					&& Selection.transforms.Length > 0
					&& Selection.transforms[0].position != prevPosition) {
				foreach (Transform transform in Selection.transforms) {
					transform.position = _autoSnapInstance.SnapToValues(transform.position);
				}
				prevPosition = Selection.transforms[0].position;
			}

			if (!EditorApplication.isPlaying
					&& Selection.transforms.Length > 0
					&& Selection.transforms[0].eulerAngles != prevRotation) {
				foreach (Transform transform in Selection.transforms) {
					transform.eulerAngles = _autoSnapInstance.SnapRotation(transform.eulerAngles);
				}
				prevRotation = Selection.transforms[0].eulerAngles;
			}
		}

		public void OnEnable() {
			EditorApplication.update += Update;
		}

		public void OnDisable() {
			_autoSnapInstance.SavePreferences();
		}
	}
}