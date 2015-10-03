using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public enum Condition {
    LESS_THAN_EQUALS_TO = 0,
    LESS_THAN = 1,
    EQUALS_TO = 2,
    GREATER_THAN = 3,
    GREATHER_THAN_EQUALS_TO = 4
	}

	public static class ConditionExtensions {
		public static bool Apply(this Condition condition, float a, float b) {
      switch (condition) {
        case Condition.LESS_THAN_EQUALS_TO:
          return a <= b;
        case Condition.LESS_THAN:
          return a < b;
        case Condition.EQUALS_TO:
          return a == b;
        case Condition.GREATER_THAN:
          return a > b;
        case Condition.GREATHER_THAN_EQUALS_TO:
        default:
          return a >= b;
      }
    }
	}
}
