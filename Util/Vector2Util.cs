using UnityEngine;

namespace DT {
  public static class Vector2Util {
    public static Vector2 Abs(Vector2 v) {
      return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
    }
  }
}