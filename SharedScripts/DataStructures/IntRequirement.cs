using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  [Serializable]
  public class IntRequirement {
    [field: NonSerialized] public event Action OnFulfilledCountChanged = delegate {};

    public int Required { get { return this._required; } }
    public int Fulfilled {
      get { return this._fulfilled; }
      set {
        if (this._fulfilled == value) {
          return;
        }

        this._fulfilled = value;
        this.OnFulfilledCountChanged.Invoke();
      }
    }


    // PRAGMA MARK - Internal
    [SerializeField] private int _required;
    private int _fulfilled;
  }

  public static class IntRequirementExtensions {
    public static bool IsComplete(this IntRequirement requirement) {
      return requirement.Fulfilled >= requirement.Required;
    }

    public static float Progress(this IntRequirement requirement) {
      return (float)requirement.Fulfilled / (float)requirement.Required;
    }
  }
}