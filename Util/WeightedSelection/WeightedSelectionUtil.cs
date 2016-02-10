using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public static class WeightedSelectionUtil {
    public static T SelectWeightedObject<T>(IEnumerable<T> collection) where T : IWeightedObject {
      int cumulativeWeight = collection.Sum(obj => obj.Weight);

      int selectedWeight = Random.Range(0, cumulativeWeight);
      foreach (T obj in collection) {
        selectedWeight -= obj.Weight;
        if (selectedWeight <= 0) {
          return obj;
        }
      }

      Debug.LogError("SelectWeightedObject - failed to select weight! Possible that Weight changed?");
      return default(T);
    }
  }
}