using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class ListExtensions {
    public static T Random<T>(this IList<T> list) {
      if (list.Count <= 0) {
        return default(T);
      }

      int chosenIndex = UnityEngine.Random.Range(0, list.Count);
      return list[chosenIndex];
    }

    public static IEnumerable<T> Repeat<T>(this IList<T> list) {
      int index = 0;
      while (true) {
        yield return list[index];
        index = MathUtil.Wrap(index + 1, 0, list.Count);
      }
    }

    public static T SafeGet<T>(this IList<T> list, int index, T defaultValue = default(T)) {
      if (index >= 0 && index < list.Count) {
        return list[index];
      } else {
        return defaultValue;
      }
    }

    public static void RemoveRange<T>(this List<T> l, IList<T> itemsToRemove) {
      for (int i = 0; i < itemsToRemove.Count; i++) {
        T item = itemsToRemove[i];
        l.Remove(item);
      }
    }
  }
}