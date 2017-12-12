using DT;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DT {
	public static class EnumerableUtil {
		public static IEnumerable<int> Range(int start, int count) {
			int current = start;
			while (count > 0) {
				yield return current;

				current++;
				count--;
			}
		}
	}
}
