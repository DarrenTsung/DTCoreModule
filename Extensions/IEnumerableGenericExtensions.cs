using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public static class IEnumerableGenericExtensions {
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

    public static T Max<T>(this IEnumerable<T> enumerable, Func<T, float> transformation) {
      float maxSoFar = float.MinValue;
      T maxElement = default(T);

      foreach (T element in enumerable) {
        float computedValue = transformation.Invoke(element);
        if (computedValue > maxSoFar) {
          maxSoFar = computedValue;
          maxElement = element;
        }
      }

      return maxElement;
    }

    public static T Random<T>(this IEnumerable<T> enumerable) {
        int index = UnityEngine.Random.Range(0, enumerable.Count());
        return enumerable.ElementAt(index);
    }

    public static float Max(this IEnumerable<float> enumerable) {
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

    public static Vector2 Average<T>(this IEnumerable<T> enumerable, Func<T, Vector2> selector) {
      int count = 0;
      Vector2 sum = Vector2.zero;

      foreach (T element in enumerable) {
        Vector2 x = selector.Invoke(element);
        sum += x;
        count++;
      }

      return sum / count;
    }

    public static List<T> ToList<T>(this IEnumerable<T> enumerable) {
      return new List<T>(enumerable);
    }

    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable) {
      return new HashSet<T>(enumerable);
    }

    public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> enumerable) {
      Dictionary<K, V> d = new Dictionary<K, V>();
      foreach (KeyValuePair<K, V> p in enumerable) {
        d[p.Key] = p.Value;
      }
      return d;
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