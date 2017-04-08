using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class IEnumerableExtensions {
		public static object EFirstOrDefault(this IEnumerable enumerable) {
			IEnumerator e = enumerable.GetEnumerator();
			while (e.MoveNext()) {
				return e.Current;
			}

			return null;
		}

		public static bool EAny(this IEnumerable enumerable, Predicate<object> matcher) {
			IEnumerator e = enumerable.GetEnumerator();
			while (e.MoveNext()) {
				if (matcher.Invoke(e.Current)) {
					return true;
				}
			}

			return false;
		}

		public static IEnumerable<T> ESelect<T>(this IEnumerable enumerable, Func<object, T> selector) {
			IEnumerator e = enumerable.GetEnumerator();
			while (e.MoveNext()) {
				yield return selector.Invoke(e.Current);
			}
		}
	}
}