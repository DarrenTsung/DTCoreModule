using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
  public static class ListExtensions {
    static Random rand = new Random();
    
    public static T PickRandom<T>(this IList<T> source) {
        return source[ListExtensions.rand.Next(source.Count)];
    }
  }
}