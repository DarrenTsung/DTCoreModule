using System.Collections;
using UnityEngine;

namespace DT {
	public static class Vector3Extensions {
		public static Vector3 SetXYZ(this Vector3 v, float x, float y, float z) {
			v.x = x;
			v.y = y;
			v.z = z;
			return v;
		}

		public static Vector3 SetXY(this Vector3 v, float x, float y) {
			v.x = x;
			v.y = y;
			return v;
		}

		public static Vector3 SetXZ(this Vector3 v, float x, float z) {
			v.x = x;
			v.z = z;
			return v;
		}

		public static Vector3 SetYZ(this Vector3 v, float y, float z) {
			v.y = y;
			v.z = z;
			return v;
		}

		public static Vector3 SetX(this Vector3 v, float x) {
			v.x = x;
			return v;
		}

		public static Vector3 SetY(this Vector3 v, float y) {
			v.y = y;
			return v;
		}

		public static Vector3 SetZ(this Vector3 v, float z) {
			v.z = z;
			return v;
		}

		public static Vector3 AddX(this Vector3 v, float x) {
			v.x = v.x + x;
			return v;
		}

		public static Vector3 AddY(this Vector3 v, float y) {
			v.y = v.y + y;
			return v;
		}

		public static Vector3 AddZ(this Vector3 v, float z) {
			v.z = v.z + z;
			return v;
		}

		public static Vector2 Vector2XZValue(this Vector3 v) {
			return new Vector2(v.x, v.z);
		}

		public static Vector3 ClampedToMagnitude(this Vector3 v, float clampedMagnitude) {
			if (v.magnitude > clampedMagnitude) {
				return v.normalized * clampedMagnitude;
			} else {
				return v;
			}
		}

		public static Vector3 Floor(this Vector3 v) {
			return new Vector3(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z));
		}
	}
}
