using System;
using System.Collections;
using System.Collections.Generic;

namespace DT {
  public class CountMap<T> : Dictionary<T, int> {
    // PRAGMA MARK - Public Interface
    public void Increment(T key) {
      this[key] = this.GetValue(key) + 1;
    }

    public void Decrement(T key) {
      this[key] = this.GetValue(key) - 1;
    }

    public int GetValue(T key) {
      return this.SafeGet(key, defaultValue: 0);
    }
  }
}