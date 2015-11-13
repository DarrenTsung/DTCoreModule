using System.Collections;
using UnityEditor;
using UnityEngine;

namespace DT {
  public static class ConvertToStringExtensions {
    public static string ToPercentageString(this float n) {
      return string.Format("{0}%", Mathf.Floor(n * 100.0f));
    }
  }
}
