using System.Collections;
using UnityEngine;

namespace DT {
	public static class EditorColorUtil {
		// PRAGMA MARK - Public Interface
		public static Color OddColor() {
			return ColorUtil.LerpWhiteBlack(0.10f);
		}

		public static Color EvenColor() {
			return ColorUtil.LerpWhiteBlack(0.15f);
		}
	}
}
