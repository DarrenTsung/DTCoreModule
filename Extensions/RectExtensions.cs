using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public static class RectExtensions {
    public static Vector2[] AllSingleUnitPointsInsideRect(this Rect r) {
      List<Vector2> allPoints = new List<Vector2>();
      for (float x = r.xMin; x <= r.xMax; x++) {
        for (float y = r.yMin; y <= r.yMax; y++) {
          allPoints.Add(new Vector2(x, y));
        }
      }

      return allPoints.ToArray();
    }

    public static Vector2 RestrictInsideBounds(this Rect r, Vector2 point) {
      float x = point.x, y = point.y;

      if (x > r.xMax) {
        x = r.xMax;
      } else if (x < r.xMin) {
        x = r.xMin;
      }

      if (y > r.yMax) {
        y = r.yMax;
      } else if (y < r.yMin) {
        y = r.yMin;
      }

      return new Vector2(x, y);
    }

    public static Vector2 DistanceOutsideBounds(this Rect r, Vector2 point) {
      Vector2 distance = Vector2.zero;

      if (point.x > r.xMax) {
        distance.x = point.x - r.xMax;
      } else if (point.x < r.xMin) {
        distance.x = point.x - r.xMin;
      }

      if (point.y > r.yMax) {
        distance.y = point.y - r.yMax;
      } else if (point.y < r.yMin) {
        distance.y = point.y - r.yMin;
      }

      return distance;
    }
  }
}
