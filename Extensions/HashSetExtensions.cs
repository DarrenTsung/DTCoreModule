using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class HashSetExtensions {
		public static bool AddRequired<T>(this HashSet<T> hashSet, T element) {
			bool added = hashSet.Add(element);
			if (!added) {
				Debug.LogWarning("Failed to add element: " + element + "!");
			}
			return added;
		}

		public static bool RemoveRequired<T>(this HashSet<T> hashSet, T element) {
			bool removed = hashSet.Remove(element);
			if (!removed) {
				Debug.LogWarning("Failed to remove element: " + element + "!");
			}
			return removed;
		}
	}
}