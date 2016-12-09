using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

namespace DT {
	public class ViewPriorityMap {
		// PRAGMA MARK - Public Interface
    public ViewPriorityMap() {}

    public ViewPriorityMap(int defaultPriority, Dictionary<string, int> priorityMap) {
      this._defaultPriority = defaultPriority;

      foreach (KeyValuePair<string, int> pair in priorityMap) {
        // make sure all keys are lower cased values
        this._priorityMap[pair.Key.ToLower()] = pair.Value;
      }
    }

		public int PriorityForPrefabName(string prefabName) {
      return this._priorityMap.SafeGet(prefabName.ToLower(), defaultValue: this._defaultPriority);
		}

    public int DefaultPriority { get { return this._defaultPriority; } }


		// PRAGMA MARK - Internal
    private Dictionary<string, int> _priorityMap = new Dictionary<string, int>();
    private int _defaultPriority = 100;
  }
}