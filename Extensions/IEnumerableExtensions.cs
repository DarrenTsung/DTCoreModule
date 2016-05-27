using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
  public static class IEnumerableExtensions {
    public static T Max<T>(this IEnumerable<T> enumerable, Func<T, int> predicate) {
      int maxSoFar = int.MinValue;
      T maxElement = default(T);

      foreach (T element in enumerable) {
        int computedValue = predicate.Invoke(element);
        if (computedValue > maxSoFar) {
          maxSoFar = computedValue;
          maxElement = element;
        }
      }

      return maxElement;
    }

    public static int Max(this IEnumerable<int> enumerable) {
      return enumerable.Max(i => i);
    }

    public static List<T> ToList<T>(this IEnumerable<T> enumerable) {
      return new List<T>(enumerable);
    }

    public static Dictionary<TKey, T> ToMapWithKeys<TKey, T>(this IEnumerable<T> enumerable, Func<T, TKey> keyTransformation) {
      Dictionary<TKey, T> map = new Dictionary<TKey, T>();
      foreach (T element in enumerable) {
        TKey key = keyTransformation.Invoke(element);
        map[key] = element;
      }
      return map;
    }
  }
}