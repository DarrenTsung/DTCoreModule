using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class IListExtensions {
    public static bool ContainsIndex(this IList list, int index) {
      return index >= 0 && index < list.Count;
    }

    public static bool ContainsIndex<T>(this IList<T> list, int index) {
      return index >= 0 && index < list.Count;
    }

    public static bool IsNullOrEmpty(this IList list) {
      return list == null || list.Count == 0;
    }
  }
}
