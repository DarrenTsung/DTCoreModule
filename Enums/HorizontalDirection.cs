using DT;
using System.Collections;
using UnityEngine;

namespace DT {
	public enum HorizontalDirection {
		RIGHT = 1,
		LEFT = 2
	}

	public static class HorizontalDirectionExtensions {
		public static float Sign(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? 1.0f : -1.0f;
		}

		public static int IntValue(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? 1 : -1;
		}

		public static HorizontalDirection Flipped(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? HorizontalDirection.LEFT : HorizontalDirection.RIGHT;
		}

		public static Vector2 VectorSign(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? Vector2.right : -Vector2.right;
		}
	}

	public static class HorizontalDirectionUtil {
		public static HorizontalDirection RandomDirection() {
			return (Random.value >= 0.5f) ? HorizontalDirection.RIGHT : HorizontalDirection.LEFT;
		}

		public static HorizontalDirection FromValue(float value) {
			return (value >= 0.0f) ? HorizontalDirection.RIGHT : HorizontalDirection.LEFT;
		}
	}
}
