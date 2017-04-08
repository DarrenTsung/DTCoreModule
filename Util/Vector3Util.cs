using UnityEngine;

namespace DT {
	public static class Vector3Util {
		public static Vector3 InverseScale(Vector3 a, Vector3 b) {
			a.x = (b.x == 0.0f) ? 0.0f : a.x / b.x;
			a.y = (b.y == 0.0f) ? 0.0f : a.y / b.y;
			a.z = (b.z == 0.0f) ? 0.0f : a.z / b.z;
			return a;
		}

		public static Vector3 RandomBetweenMinMaxVectors(Vector3 min, Vector3 max) {
			if (min.x > max.x || min.y > max.y || min.z > max.z) {
				Debug.LogError("RandomBetweenMinMaxVectors - min (" + min + ") greater than max (" + max + ")!");
			}

			return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
		}
	}
}