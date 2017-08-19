using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
	public static class IEnumerableGenericExtensions {
		public static T MaxBy<T>(this IEnumerable<T> enumerable, Func<T, int> transformation) {
			int maxSoFar = int.MinValue;
			T maxElement = default(T);

			foreach (T element in enumerable) {
				int computedValue = transformation.Invoke(element);
				if (computedValue > maxSoFar) {
					maxSoFar = computedValue;
					maxElement = element;
				}
			}

			return maxElement;
		}

		public static int MaxBy(this IEnumerable<int> enumerable) {
			return enumerable.MaxBy(i => i);
		}

		public static float MaxBy(this IEnumerable<float> enumerable) {
			return enumerable.MaxBy(i => i);
		}

		public static T MaxBy<T>(this IEnumerable<T> enumerable, Func<T, float> transformation) {
			float maxSoFar = float.MinValue;
			T maxElement = default(T);

			foreach (T element in enumerable) {
				float computedValue = transformation.Invoke(element);
				if (computedValue > maxSoFar) {
					maxSoFar = computedValue;
					maxElement = element;
				}
			}

			return maxElement;
		}

		public static T Random<T>(this IEnumerable<T> enumerable) {
			int index = UnityEngine.Random.Range(0, enumerable.Count());
			return enumerable.ElementAt(index);
		}

		public static T MinBy<T>(this IEnumerable<T> enumerable, Func<T, float> transformation) {
			float minSoFar = float.MaxValue;
			T minElement = default(T);

			foreach (T element in enumerable) {
				float computedValue = transformation.Invoke(element);
				if (computedValue < minSoFar) {
					minSoFar = computedValue;
					minElement = element;
				}
			}

			return minElement;
		}

		public static T MinBy<T>(this IEnumerable<T> enumerable, Func<T, int> transformation) {
			return enumerable.MinBy((T elem) => (float)transformation.Invoke(elem));
		}

		public static int MinBy(this IEnumerable<int> enumerable) {
			return enumerable.MinBy(i => i);
		}

		public static bool All<T>(this IEnumerable<T> enumerable, Predicate<T> predicate) {
			foreach (T element in enumerable) {
				if (!predicate.Invoke(element)) {
					return false;
				}
			}

			return true;
		}

		public static Vector2 Average(this IEnumerable<Vector2> enumerable) {
			int count = 0;
			Vector2 sum = Vector2.zero;

			foreach (Vector2 element in enumerable) {
				sum += element;
				count++;
			}

			return sum / count;
		}

		public static Vector3 Average(this IEnumerable<Vector3> enumerable) {
			int count = 0;
			Vector3 sum = Vector2.zero;

			foreach (Vector3 element in enumerable) {
				sum += element;
				count++;
			}

			return sum / count;
		}

		public static List<T> ToList<T>(this IEnumerable<T> enumerable) {
			return new List<T>(enumerable);
		}

		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable) {
			return new HashSet<T>(enumerable);
		}

		public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> enumerable) {
			Dictionary<K, V> d = new Dictionary<K, V>();
			foreach (KeyValuePair<K, V> p in enumerable) {
				d[p.Key] = p.Value;
			}
			return d;
		}

		public static Dictionary<TKey, T> ToMapWithKeys<TKey, T>(this IEnumerable<T> enumerable, Func<T, TKey> keyTransformation) {
			Dictionary<TKey, T> map = new Dictionary<TKey, T>();
			foreach (T element in enumerable) {
				TKey key = keyTransformation.Invoke(element);
				map[key] = element;
			}
			return map;
		}

		/// <summary>Adds a single element to the end of an IEnumerable.</summary>
		/// <typeparam name="T">Type of enumerable to return.</typeparam>
		/// <returns>IEnumerable containing all the input elements, followed by the
		/// specified additional element.</returns>
		public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T element) {
			if (source == null) {
				throw new ArgumentNullException("source");
			}

			return ConcatIterator(element, source, false);
		}

		/// <summary>Adds a single element to the start of an IEnumerable.</summary>
		/// <typeparam name="T">Type of enumerable to return.</typeparam>
		/// <returns>IEnumerable containing the specified additional element, followed by
		/// all the input elements.</returns>
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> tail, T head) {
			if (tail == null) {
				throw new ArgumentNullException("tail");
			}

			return ConcatIterator(head, tail, true);
		}

		private static IEnumerable<T> ConcatIterator<T>(T extraElement, IEnumerable<T> source, bool insertAtStart) {
			if (insertAtStart) {
				yield return extraElement;
			}

			foreach (var e in source) {
				yield return e;
			}

			if (!insertAtStart) {
				yield return extraElement;
			}
		}

		public static T FirstOrDefault<T>(this IEnumerable<T> enumerable) {
			foreach (T elem in enumerable) {
				return elem;
			}

			return default(T);
		}

		public static T FirstOrDefault<T>(this IEnumerable<T> enumerable, Predicate<T> predicate) {
			foreach (T elem in enumerable) {
				if (predicate.Invoke(elem)) {
					return elem;
				}
			}

			return default(T);
		}
	}
}