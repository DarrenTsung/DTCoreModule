using System;
using UnityEngine;

namespace DT {
	[Serializable]
	public struct FloatRange {
		public float Min;
		public float Max;

		public FloatRange(float min, float max) {
			Min = min;
			Max = max;
		}
	}

	public static class FloatRangeExtensions {
		public static float Next(this FloatRange range) {
			return UnityEngine.Random.Range(range.Min, range.Max);
		}
	}
}