using System.Collections;
using UnityEngine;

namespace DT {
	public static class RectUtil {
		public static Rect MakeRect(Vector2 position, Vector2 size, Vector2 pivot = default(Vector2)) {
			position = position - Vector2.Scale(size, pivot);
			return new Rect(position, size);
		}

		public static Rect MakeRect(Bounds b) {
			return new Rect(b.center - b.extents, b.extents * 2.0f);
		}

		public static Rect Expand(Rect r, float amount) {
			float halfAmount = amount / 2.0f;

			r.position = r.position - new Vector2(halfAmount, halfAmount);
			r.size = r.size + new Vector2(amount, amount);

			return r;
		}
	}
}