using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
  public static class IEnumerableExtensions {
    public static T Max<T>(this IEnumerable<T> enumerable, Func<T, int> transformation) {
      int maxSoFar = int.MinValue;
      T maxElement = default(T);

      foreach (T element in enumerable) {
        int computedValue = transformation.Invoke(element);
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

    public static T Min<T>(this IEnumerable<T> enumerable, Func<T, int> transformation) {
      int minSoFar = int.MaxValue;
      T minElement = default(T);

      foreach (T element in enumerable) {
        int computedValue = transformation.Invoke(element);
        if (computedValue < minSoFar) {
          minSoFar = computedValue;
          minElement = element;
        }
      }

      return minElement;
    }

    public static int Min(this IEnumerable<int> enumerable) {
      return enumerable.Min(i => i);
    }

    public static bool All<T>(this IEnumerable<T> enumerable, Predicate<T> predicate) {
      foreach (T element in enumerable) {
        if (!predicate.Invoke(element)) {
          return false;
        }
      }

      return true;
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