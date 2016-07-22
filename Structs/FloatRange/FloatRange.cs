using System;
using UnityEngine;

namespace DT {
  [Serializable]
  public struct FloatRange {
    public float min;
    public float max;
  }

  public static class FloatRangeExtensions {
    public static float SampleRandom(this FloatRange range) {
      return UnityEngine.Random.Range(range.min, range.max);
    }
  }
}