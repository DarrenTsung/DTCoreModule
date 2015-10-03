using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public enum RotationDirection {
		CLOCKWISE = 0,
		COUNTER_CLOCKWISE = 1
	}

	public static class RotationDirectionExtensions {
		public static RotationDirection Flipped(this RotationDirection direction) {
			return (direction == RotationDirection.CLOCKWISE) ? RotationDirection.COUNTER_CLOCKWISE : RotationDirection.CLOCKWISE;
		}
	}
}
