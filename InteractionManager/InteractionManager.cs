using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT {
	public static class InteractionManager {
    // PRAGMA MARK - Public Interface
    public static void Initialize() {
      ObjectPoolManager.OnGameObjectInstantiated += InteractionManager.HandleGameObjectInstantiated;
    }

    public static void DisableInteractionFor(float seconds) {
      if (InteractionManager._disabledForSecondsCoroutine != null) {
        InteractionManager._disabledForSecondsCoroutine.Cancel();
        InteractionManager._disabledForSecondsCoroutine = null;
      } else {
        InteractionManager.DisableInteraction();
      }

      InteractionManager._disabledForSecondsCoroutine = CoroutineWrapper.DoAfterDelay(seconds, InteractionManager.ReenableInteraction);
    }

    public static void ReenableInteractionAfter(float seconds) {
      if (InteractionManager._reenableAfterSecondsCoroutine != null) {
        return;
      }

      InteractionManager._reenableAfterSecondsCoroutine = CoroutineWrapper.DoAfterDelay(seconds, InteractionManager.ReenableInteraction);
    }

    public static void DisableInteraction() {
      if (InteractionManager._reenableAfterSecondsCoroutine != null) {
        InteractionManager._reenableAfterSecondsCoroutine.Cancel();
        InteractionManager._reenableAfterSecondsCoroutine = null;
      }

      foreach (Selectable s in InteractionManager.AllSelectables()) {
        InteractionManager.DisableSelectable(s);
      }
    }

    public static void ReenableInteraction() {
      InteractionManager._reenableAfterSecondsCoroutine = null;

      foreach (Selectable s in InteractionManager.AllSelectables()) {
        InteractionManager.ReenableSelectable(s);
      }
    }

    public static void ReenableInteractionForGameObjectsMatching(Predicate<GameObject> predicate) {
      bool objectMatchedPredicate = false;

      foreach (Selectable s in InteractionManager.AllSelectables(predicate)) {
        objectMatchedPredicate = true;
        InteractionManager.ReenableSelectable(s);
      }

      if (!objectMatchedPredicate) {
        Debug.LogWarning("Failed to find object matching predicate, probably unexpected behaviour!");
      }
    }

    public static void ReenableSelectablesInGameObject(GameObject g) {
      Selectable[] selectables = g.GetComponentsInChildren<Selectable>(includeInactive: true);
      foreach (Selectable s in selectables) {
        InteractionManager.ReenableSelectable(s);
      }
    }




    // PRAGMA MARK - Static Internal
    private static Dictionary<GameObject, Selectable[]> _selectableMap = new Dictionary<GameObject, Selectable[]>();
    private static HashSet<Selectable> _selectablesToReenable = new HashSet<Selectable>();

    private static CoroutineWrapper _disabledForSecondsCoroutine;
    private static CoroutineWrapper _reenableAfterSecondsCoroutine;

    private static void HandleGameObjectInstantiated(GameObject g) {
      Selectable[] selectables = g.GetComponentsInChildren<Selectable>(includeInactive: true);
      InteractionManager._selectableMap[g] = selectables;
    }

    private static void DisableSelectable(Selectable s) {
      if (s.interactable == false) {
        return;
      }

      if (InteractionManager._selectablesToReenable.Contains(s)) {
        Debug.LogWarning("DisableSelectable that is already in selectables to reenable!");
      }

      s.interactable = false;
      InteractionManager._selectablesToReenable.Add(s);
    }

    private static void ReenableSelectable(Selectable s) {
      if (!InteractionManager._selectablesToReenable.Contains(s)) {
        return;
      }

      if (s.interactable) {
        Debug.LogWarning("ReenableSelectable that is already interactable!");
      }

      s.interactable = true;
      InteractionManager._selectablesToReenable.Remove(s);
    }

    private static IEnumerable<Selectable> AllSelectables(Predicate<GameObject> predicate = null) {
      // delay instantiation of new list only if we find a GameObject that is null
      List<GameObject> keysToRemove = null;

      foreach (KeyValuePair<GameObject, Selectable[]> pair in InteractionManager._selectableMap) {
        GameObject g = pair.Key;
        if (g == null) {
          if (keysToRemove == null) {
            keysToRemove = new List<GameObject>();
          }
          keysToRemove.Add(g);
          continue;
        }

        if (predicate != null) {
          bool matches = predicate.Invoke(g);
          if (!matches) {
            continue;
          }
        }

        Selectable[] selectables = pair.Value;
        foreach (Selectable s in selectables) {
          yield return s;
        }
      }

      if (keysToRemove != null) {
        foreach (GameObject key in keysToRemove) {
          InteractionManager._selectableMap.Remove(key);
        }
      }
    }
	}
}