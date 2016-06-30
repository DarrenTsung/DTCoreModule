using System.Collections;
using UnityEngine;

namespace DT {
  public struct QuadBezierV2 {
    public Vector2 start;
    public Vector2 control;
    public Vector2 end;

    public QuadBezierV2(Vector2 start, Vector2 control, Vector2 end) {
      this.start = start;
      this.control = control;
      this.end = end;
    }
  }

  public static class QuadBezierV2Extensions {
    public static Vector2 Evaluate(this QuadBezierV2 q, float t) {
      return BezierUtil.Quad(q.start, q.control, q.end, t);
    }
  }
}