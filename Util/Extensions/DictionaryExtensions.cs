using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DT {
  public static class DictionaryExtensions {
    static Random rand = new Random();
    
    public static T PickRandomWeighted<T>(this IDictionary<T, int> source) {
      if (source.Count <= 0) {
        return default(T);
      }
      
      int weightSum = source.Sum(x => x.Value);
      int chosenIndex = DictionaryExtensions.rand.Next(weightSum);
      
      foreach (KeyValuePair<T, int> pair in source) {
        int weight = pair.Value;
        if (chosenIndex < weight) {
          return pair.Key;
        }
        chosenIndex -= weight;
      }
      return default(T);
    }
  }
}