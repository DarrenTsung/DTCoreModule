using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class IListExtensions {
		public static void ReverseForeach<T>(this IList<T> list, Action<T> action) {
			for (int i = list.Count - 1; i >= 0; i--) {
				action.Invoke(list[i]);
			}
		}

		public static T GetValueOrCreateNew<T>(this IList<T> list, int index) where T : class, new() {
			if (!list.ContainsIndex(index)) {
				return null;
			}

			if (list[index] == null) {
				list[index] = new T();
			}

			return list[index];
		}

		public static IEnumerable<T> ListReverse<T>(this IList<T> list) {
			for (int i = list.Count - 1; i >= 0; i--) {
				yield return list[i];
			}
		}

		public static T Random<T>(this IList<T> list) {
			if (list.Count <= 0) {
				return default(T);
			}

			int chosenIndex = UnityEngine.Random.Range(0, list.Count);
			return list[chosenIndex];
		}

		public static bool IsEmpty<T>(this IList<T> list) {
			return list.Count <= 0;
		}

		public static T Random<T>(this IList<T> list, int seed) {
			UnityEngine.Random.State oldState = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			T item = list.Random();
			UnityEngine.Random.state = oldState;
			return item;
		}

		public static void Shuffle<T>(this IList<T> list) {
			var count = list.Count;
			var last = count - 1;
			for (var i = 0; i < last; ++i) {
				var r = UnityEngine.Random.Range(i, count);
				var tmp = list[i];
				list[i] = list[r];
				list[r] = tmp;
			}
		}

		public static IEnumerable<T> Repeat<T>(this IList<T> list) {
			int index = 0;
			while (true) {
				yield return list[index];
				index = list.WrapIndex(index + 1);
			}
		}

		public static T GetRequiredValueOrDefault<T>(this IList<T> list, int index, T defaultValue = default(T)) {
			if (list.ContainsIndex(index)) {
				return list[index];
			} else {
				Debug.LogError("Failed to find required value for index: " + index);
				return defaultValue;
			}
		}

		public static T GetValueOrDefault<T>(this IList<T> list, int index, T defaultValue = default(T)) {
			if (list.ContainsIndex(index)) {
				return list[index];
			} else {
				return defaultValue;
			}
		}

		public static T GetClamped<T>(this IList<T> list, int index) {
			return list[list.ClampIndex(index)];
		}

		public static T GetWrapped<T>(this IList<T> list, int index) {
			return list[list.WrapIndex(index)];
		}

		public static void RemoveRange<T>(this List<T> l, IList<T> itemsToRemove) {
			for (int i = 0; i < itemsToRemove.Count; i++) {
				T item = itemsToRemove[i];
				l.Remove(item);
			}
		}

		public static void RemoveLast<T>(this List<T> l) {
			l.RemoveAt(l.Count - 1);
		}

		public static IEnumerable<T> Join<T>(this IList<T> l, T separator) {
			for (int i = 0; i < l.Count - 1; i++) {
				yield return l[i];
				yield return separator;
			}

			yield return l[l.Count - 1];
		}

		public static bool ContainsIndex(this IList list, int index) {
			return index >= 0 && index < list.Count;
		}

		public static bool IsNullOrEmpty(this IList list) {
			return list == null || list.Count == 0;
		}

		public static int ClampIndex(this IList l, int i) {
			return MathUtil.Clamp(i, 0, l.Count - 1);
		}

		public static int WrapIndex(this IList l, int i) {
			return MathUtil.Wrap(i, 0, l.Count);
		}

		// NOTE (darren): functions that are the same between IList<T> / IList
		// will conflict because arrays / lists are both - hide one version since we
		// only need two versions in this class
		private static bool ContainsIndex<T>(this IList<T> list, int index) {
			return index >= 0 && index < list.Count;
		}

		private static bool IsNullOrEmpty<T>(this IList<T> list) {
			return list == null || list.Count == 0;
		}

		private static int WrapIndex<T>(this IList<T> l, int i) {
			return MathUtil.Wrap(i, 0, l.Count);
		}

		private static int ClampIndex<T>(this IList<T> l, int i) {
			return MathUtil.Clamp(i, 0, l.Count - 1);
		}
	}
}
