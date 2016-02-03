using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public static class PlaneExtensions {
    public static Vector3 GetIntersectionForScreenPosition(this Plane p, Vector2 screenPosition) {
      Ray ray = Camera.main.ScreenPointToRay(screenPosition);

      float rayDistance;
      if (p.Raycast(ray, out rayDistance)) {
        return ray.GetPoint(rayDistance);
      }

      return Vector3.zero;
    }
  }
}
