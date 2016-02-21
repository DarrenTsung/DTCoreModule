using DT;
using System.Linq;
using UnityEngine;

namespace DT {
  public static class GizmosUtil {
    public static void DrawWorldSpaceRect(Rect rect, float z = 0.0f) {
      Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMin, z), new Vector3(rect.xMax, rect.yMin, z));
      Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMax, z), new Vector3(rect.xMax, rect.yMax, z));
      Gizmos.DrawLine(new Vector3(rect.xMin, rect.yMin, z), new Vector3(rect.xMin, rect.yMax, z));
      Gizmos.DrawLine(new Vector3(rect.xMax, rect.yMin, z), new Vector3(rect.xMax, rect.yMax, z));
    }
  }
}
