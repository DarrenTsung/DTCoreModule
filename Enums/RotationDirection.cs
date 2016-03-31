using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public enum RotationDirection {
		CLOCKWISE = 1,
		COUNTER_CLOCKWISE = 2
	}

	public static class RotationDirectionExtensions {
    public static float FloatValue(this RotationDirection direction) {
      if (direction == RotationDirection.CLOCKWISE) {
        return -1.0f;
      } else {
        return 1.0f;
      }
    }

		public static RotationDirection Flipped(this RotationDirection direction) {
			return (direction == RotationDirection.CLOCKWISE) ? RotationDirection.COUNTER_CLOCKWISE : RotationDirection.CLOCKWISE;
		}
	}
}
