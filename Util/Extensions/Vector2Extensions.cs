using System.Collections;
using UnityEngine;

namespace DT {
  public static class Vector2Extensions {
    public static Vector2 SetXY(this Vector2 v, float x, float y) {
      v.x = x;
      v.y = y;
      return v;
    }
    
    public static Vector2 SetX(this Vector2 v, float x) {
      v.x = x;
      return v;
    }
    
    public static Vector2 SetY(this Vector2 v, float y) {
      v.y = y;
      return v;
    }
    
    public static Vector2 AddX(this Vector2 v, float x) {
      v.x = v.x + x;
      return v;
    }
    
    public static Vector2 AddY(this Vector2 v, float y) {
      v.y = v.y + y;
      return v;
    }
    
    public static Vector2 PerpendicularDirection(this Vector2 v) {
      Vector2 p = new Vector2(-v.y, v.x);
      return p.normalized;
    }
    
    public static Vector2 PerpendicularVector(this Vector2 v) {
      Vector2 p = new Vector2(-v.y, v.x);
      return p;
    }
    
    public static Vector2 CenterPoint(this Vector2[] points) {
  		Vector2 centerPoint = new Vector2(0.0f, 0.0f);
  		foreach (Vector2 point in points) {
  			centerPoint += point;
  		}
  		return new Vector2(centerPoint.x / points.Length, centerPoint.y / points.Length);
    }
    
    /**
    * Get the minimum distance between a line segment and point
    *
    * @param {point} - Point
    * @param {lineStart} - One point in the line segment
    * @param {lineEnd} - Other point in the line segment
    */
    public static float MinimumDistanceToLine(this Vector2 point, Vector2 lineStart, Vector2 lineEnd) {
      Vector2 lineVector = lineEnd - lineStart;
      if (lineVector.magnitude == 0.0f) {
        return (lineStart - point).magnitude;
      }
      
      // Find the projection of the point onto the line (lineStart + t * (lineEnd - lineStart))
      float t = Vector2.Dot(point - lineStart, lineVector) / Vector2.Dot(lineVector, lineVector);
      if (t < 0.0f) {
        return (point - lineStart).magnitude;	  // Off the line, closest to lineStart
      } else if (t > 1.0f) {
        return (point - lineEnd).magnitude; 		// Off the line, closest to lineEnd
      } else {
        // Projection falls on the line
        Vector2 projectionPoint = lineStart + t * lineVector;
        return (point - projectionPoint).magnitude;
      }
    }
    
    public static Vector2 Rotate(this Vector2 v, float degrees) {
      return Quaternion.Euler(0, 0, degrees) * v;
    }
  }
}
