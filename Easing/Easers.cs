using DT;
using System.Collections;
using UnityEngine;

namespace DT {
	public class Easers : MonoBehaviour {
		// PRAGMA MARK - Unclamped Lerps
		public static float UnclampedLerp(float from, float to, float t) {
			return from + (to - from) * t;
		}
		
		
		// PRAGMA MARK - Easers 
		public static float Ease(EaseType easeType, float from, float to, float t, float duration) {
			return UnclampedLerp(from, to, EaseHelper.Ease(easeType, t, duration));
		}
	}
}