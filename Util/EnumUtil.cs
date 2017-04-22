using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DT {
	public static class EnumUtil {
		public static T ClampMove<T>(T elem, int positions) {
			Array enumValues = Enum.GetValues(typeof(T));
			int index = Array.IndexOf(enumValues, elem) + positions;
			return (T)enumValues.GetValue(MathUtil.Clamp(index, 0, enumValues.Length));
		}
	}
}
