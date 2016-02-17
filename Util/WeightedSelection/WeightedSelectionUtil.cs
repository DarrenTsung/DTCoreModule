using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
  public static class WeightedSelectionUtil {
    public static T SelectWeightedObject<T>(IEnumerable<T> collection) where T : IWeightedObject {
      if (collection == null) {
        Debug.LogWarning("SelectWeightedObject - passed in null collection!");
        return default(T);
      }

      int cumulativeWeight = collection.Sum(obj => obj.Weight);
      if (cumulativeWeight == 0) {
        Debug.LogWarning("SelectWeightedObject - cumulative weight is 0!");
        return default(T);
      }

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