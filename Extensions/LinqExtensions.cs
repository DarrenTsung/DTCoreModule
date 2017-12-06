using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT.Linq {
	public static class LinqExtensions {
		public static List<T> ToList<T>(this IEnumerable<T> enumerable) {
			return new List<T>(enumerable);
		}
	}
}