using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

namespace DT {
	public class ViewManager : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void AttachView(GameObject view) {
      view.transform.SetParent(this.transform, worldPositionStays: false);

      RecyclablePrefab r = view.GetRequiredComponent<RecyclablePrefab>();
      if (this._priorityMap == null) {
        Debug.LogError("ViewManager - no priority configuration when attaching view!");
        return;
      }

      int priority = this._priorityMap.PriorityForPrefabName(r.prefabName);
      this._cachedPriorities[view.transform] = priority;

      for (int i = 0; i < this.transform.childCount; i++) {
        Transform child = this.transform.GetChild(i);

        if (!this._cachedPriorities.ContainsKey(child)) {
          Debug.LogError("Child transform of ViewManager is not in cached priorties, didn't go through ViewManager flow?");
          continue;
        }

        int childPriority = this._cachedPriorities[child];
        if (childPriority > priority) {
          view.transform.SetSiblingIndex(i);
          break;
        }
      }
		}

    public void ConfigureWithPriority(ViewPriorityMap priorityMap) {
      this._priorityMap = priorityMap;
    }


		// PRAGMA MARK - Internal
    private ViewPriorityMap _priorityMap;
    private Dictionary<Transform, int> _cachedPriorities = new Dictionary<Transform, int>();
  }
}