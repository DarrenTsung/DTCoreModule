using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DT {
	public static class PropertyInfoExtensions {
		public static object GetValue(this PropertyInfo p, object obj) {
			return p.GetValue(obj, invokeAttr: BindingFlags.Default, binder: null, index: null, culture: null);
		}
	}
}
