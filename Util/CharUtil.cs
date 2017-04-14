using UnityEngine;

namespace DT {
	public static class CharUtil {
		public static char RandomLowercaseLetter() {
			return (char)('a' + UnityEngine.Random.Range(0, 26));
		}

		public static char RandomUppercaseLetter() {
			return char.ToUpper(RandomLowercaseLetter());
		}
	}
}