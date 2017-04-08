using UnityEngine;

namespace DT {
	public struct Line2D {
		public float offsetAt0;
		public float slope;

		public Line2D(Vector2 point1, Vector2 point2) {
			Vector2 lineVector = (point2.x > point1.x) ? point2 - point1 : point1 - point2;

			// ex. line from (0, 0) to (0, 3), this would be 1
			this.slope = lineVector.y / lineVector.x;
			this.offsetAt0 = point1.y + (this.slope * -point1.x);
		}
	}

	public static class Line2DUtil {
		public static bool IsPointAboveOrOnLine(Vector2 pos, Line2D line) {
			return line.YPositionAtX(pos.x) <= pos.y;
		}

		public static bool IsPointBelowLine(Vector2 pos, Line2D line) {
			return line.YPositionAtX(pos.x) > pos.y;
		}
	}

	public static class Line2DExtensions {
		public static float YPositionAtX(this Line2D line, float x) {
			return line.offsetAt0 + (x * line.slope);
		}

		public static Vector2 PointAtX(this Line2D line, float x) {
			return new Vector2(x, line.YPositionAtX(x));
		}
	}
}