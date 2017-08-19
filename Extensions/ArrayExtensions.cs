using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
	public static class ArrayExtensions {
		public static void Shuffle<T> (this T[] array) {
			int n = array.Length;
			while (n > 1) {
				int k = UnityEngine.Random.Range(0, n--);
				T temp = array[n];
				array[n] = array[k];
				array[k] = temp;
			}
		}
	}
}
