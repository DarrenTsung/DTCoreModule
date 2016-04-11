using System.Collections;
using UnityEngine;

namespace DT {
  public static class FloatRangeExtensions {
    // PRAGMA MARK - Static
    public static float SampleRandom(this FloatRange floatRange) {
      return Random.Range(floatRange.min, floatRange.max);
    }
  }
}