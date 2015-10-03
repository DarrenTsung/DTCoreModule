using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public enum HorizontalDirection {
		RIGHT = 0,
		LEFT = 1
	}

	public static class HorizontalDirectionExtensions {
		public static float Sign(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? 1.0f : -1.0f;
		}
		
		public static HorizontalDirection Flip(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? HorizontalDirection.LEFT : HorizontalDirection.RIGHT;
		}
		
		public static Vector2 VectorSign(this HorizontalDirection direction) {
			return (direction == HorizontalDirection.RIGHT) ? Vector2.right : -Vector2.right;
		}
	}
}
