using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DT {
	public static class RandomUtil {
		public static bool RandomChance(float chance) {
			return UnityEngine.Random.Range(0.0f, 1.0f) <= chance;
		}
	}
}
