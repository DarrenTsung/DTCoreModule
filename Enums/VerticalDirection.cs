using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public enum VerticalDirection {
		UP = 1,
		DOWN = 2
	}

	public static class VerticalDirectionExtensions {
		public static float Sign(this VerticalDirection direction) {
			return (direction == VerticalDirection.UP) ? 1.0f : -1.0f;
		}

		public static VerticalDirection Flip(this VerticalDirection direction) {
			return (direction == VerticalDirection.UP) ? VerticalDirection.DOWN : VerticalDirection.UP;
		}

		public static Vector2 VectorSign(this VerticalDirection direction) {
			return (direction == VerticalDirection.UP) ? Vector2.up : -Vector2.up;
		}
	}

  public static class VerticalDirectionUtil {
    public static VerticalDirection RandomDirection() {
      return (Random.value > 0.5f) ? VerticalDirection.UP : VerticalDirection.DOWN;
    }
  }
}
