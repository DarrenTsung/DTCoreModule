using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public enum VectorAxis {
		X = 1,
		Y = 2,
    Z = 4,
	}

	public static class VectorAxisExtensions {
    public static Vector3 VectorValue(this VectorAxis axis) {
      float x = 0.0f, y = 0.0f, z = 0.0f;

      if (axis.HasFlag(VectorAxis.X)) {
        x = 1.0f;
      }

      if (axis.HasFlag(VectorAxis.Y)) {
        y = 1.0f;
      }

      if (axis.HasFlag(VectorAxis.Z)) {
        z = 1.0f;
      }

      return new Vector3(x, y, z);
    }
	}
}
