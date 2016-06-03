using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
  public static class ListExtensions {
    static Random rand = new Random();

    public static T PickRandom<T>(this IList<T> source) {
        return source[ListExtensions.rand.Next(source.Count)];
    }

    public static T SafeGet<T>(this IList<T> source, int index, T defaultValue = default(T)) {
      if (index >= 0 && index < source.Count) {
        return source[index];
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