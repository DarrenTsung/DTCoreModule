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
  }
}
