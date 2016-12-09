using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT {
	public class ViewManager : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void AttachView(GameObject view) {
      view.transform.SetParent(this.transform, worldPositionStays: false);

      // if the application is not playing, we don't need to manage the view order
      if (!Application.isPlaying) {
        return;
      }

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
          Debug.LogWarning(string.Format("Child ({0}) is not in cached priorties, didn't go through ViewManager flow?", child.gameObject.name));
          this._cachedPriorities[child] = this._priorityMap.DefaultPriority;
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

    public Canvas Canvas {
      get { return this._canvas; }
    }

    public CanvasScaler CanvasScaler {
      get { return this._canvasScaler; }
    }


		// PRAGMA MARK - Internal
    private ViewPriorityMap _priorityMap = new ViewPriorityMap();
    private Dictionary<Transform, int> _cachedPriorities = new Dictionary<Transform, int>();

    private Canvas _canvas;
    private CanvasScaler _canvasScaler;

    void Awake() {
      this._canvas = this.GetComponent<Canvas>();
      this._canvasScaler = this.GetComponent<CanvasScaler>();
    }
  }
}