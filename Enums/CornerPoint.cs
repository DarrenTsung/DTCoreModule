using DT;
using System.Collections;
using UnityEngine;

namespace DT {
	public enum CornerPoint {
		TopLeft = 1,
		TopRight = 2,
		BottomLeft = 3,
		BottomRight = 4,
	}

	public static class CornerPointExtensions {
		public static bool IsBottom(this CornerPoint cp) {
			return cp == CornerPoint.BottomLeft || cp == CornerPoint.BottomRight;
		}

		public static bool IsTop(this CornerPoint cp) {
			return cp == CornerPoint.TopLeft || cp == CornerPoint.TopRight;
		}

		public static bool IsLeft(this CornerPoint cp) {
			return cp == CornerPoint.BottomLeft || cp == CornerPoint.TopLeft;
		}

		public static bool IsRight(this CornerPoint cp) {
			return cp == CornerPoint.BottomRight || cp == CornerPoint.TopRight;
		}

		public static Vector2 ToVector2(this CornerPoint cp) {
			switch (cp) {
				case CornerPoint.TopLeft:
					return new Vector2(0.0f, 1.0f);
				case CornerPoint.TopRight:
					return new Vector2(1.0f, 1.0f);
				case CornerPoint.BottomLeft:
					return new Vector2(0.0f, 0.0f);
				case CornerPoint.BottomRight:
				default:
					return new Vector2(1.0f, 0.0f);
			}
		}
	}
}
