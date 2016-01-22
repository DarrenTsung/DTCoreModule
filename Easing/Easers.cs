using DT;
using System.Collections;
using UnityEngine;

/// All taken from prime31's ZestKit here: https://github.com/prime31/ZestKit/blob/master/Assets/ZestKit/Easing/Zest.cs
namespace DT {
	public class Easers {
    public static EaseType DefaultEaseType = EaseType.QuadOut;

		// PRAGMA MARK - Unclamped Lerps
		public static float UnclampedLerp(float from, float to, float t) {
			return from + (to - from) * t;
		}

		public static Vector2 UnclampedLerp(Vector2 from, Vector2 to, float t) {
			return new Vector2(
        Easers.UnclampedLerp(from.x, to.x, t),
        Easers.UnclampedLerp(from.y, to.y, t)
      );
		}


		// PRAGMA MARK - Easers
		public static float Ease(EaseType easeType, float from, float to, float t, float duration) {
			return Easers.UnclampedLerp(from, to, EaseHelper.Ease(easeType, t, duration));
		}

		public static Vector2 Ease(EaseType easeType, Vector2 from, Vector2 to, float t, float duration) {
			return Easers.UnclampedLerp(from, to, EaseHelper.Ease(easeType, t, duration));
		}


		// PRAGMA MARK - Springs
		/// <summary>
		/// uses the semi-implicit euler method. faster, but not always stable.
		/// see http://allenchou.net/2015/04/game-math-more-on-numeric-springing/
		/// </summary>
		/// <returns>The spring.</returns>
		/// <param name="currentValue">Current value.</param>
		/// <param name="targetValue">Target value.</param>
		/// <param name="velocity">Velocity by reference. Be sure to reset it to 0 if changing the targetValue between calls</param>
		/// <param name="dampingRatio">lower values are less damped and higher values are more damped resulting in less springiness.
		/// should be between 0.01f, 1f to avoid unstable systems.</param>
		/// <param name="angularFrequency">An angular frequency of 2pi (radians per second) means the oscillation completes one
		/// full period over one second, i.e. 1Hz. should be less than 35 or so to remain stable</param>
		public static float FastSpring(float currentValue, float targetValue, ref float velocity, float dampingRatio, float angularFrequency) {
			velocity += -2.0f * Time.deltaTime * dampingRatio * angularFrequency * velocity + Time.deltaTime * angularFrequency * angularFrequency * (targetValue - currentValue);
			currentValue += Time.deltaTime * velocity;

			return currentValue;
		}


		/// <summary>
		/// uses the implicit euler method. slower, but always stable.
		/// see http://allenchou.net/2015/04/game-math-more-on-numeric-springing/
		/// </summary>
		/// <returns>The spring.</returns>
		/// <param name="currentValue">Current value.</param>
		/// <param name="targetValue">Target value.</param>
		/// <param name="velocity">Velocity by reference. Be sure to reset it to 0 if changing the targetValue between calls</param>
		/// <param name="dampingRatio">lower values are less damped and higher values are more damped resulting in less springiness.
		/// should be between 0.01f, 1f to avoid unstable systems.</param>
		/// <param name="angularFrequency">An angular frequency of 2pi (radians per second) means the oscillation completes one
		/// full period over one second, i.e. 1Hz. should be less than 35 or so to remain stable</param>
		public static float StableSpring(float currentValue, float targetValue, ref float velocity, float dampingRatio, float angularFrequency) {
			var f = 1f + 2f * Time.deltaTime * dampingRatio * angularFrequency;
			var oo = angularFrequency * angularFrequency;
			var hoo = Time.deltaTime * oo;
			var hhoo = Time.deltaTime * hoo;
			var detInv = 1.0f / (f + hhoo);
			var detX = f * currentValue + Time.deltaTime * velocity + hhoo * targetValue;
			var detV = velocity + hoo * (targetValue - currentValue);

			currentValue = detX * detInv;
			velocity = detV * detInv;

			return currentValue;
		}


		/// <summary>
		/// uses the semi-implicit euler method. slower, but always stable.
		/// see http://allenchou.net/2015/04/game-math-more-on-numeric-springing/
		/// </summary>
		/// <returns>The spring.</returns>
		/// <param name="currentValue">Current value.</param>
		/// <param name="targetValue">Target value.</param>
		/// <param name="velocity">Velocity by reference. Be sure to reset it to 0 if changing the targetValue between calls</param>
		/// <param name="dampingRatio">lower values are less damped and higher values are more damped resulting in less springiness.
		/// should be between 0.01f, 1f to avoid unstable systems.</param>
		/// <param name="angularFrequency">An angular frequency of 2pi (radians per second) means the oscillation completes one
		/// full period over one second, i.e. 1Hz. should be less than 35 or so to remain stable</param>
		public static Vector3 FastSpring(Vector3 currentValue, Vector3 targetValue, ref Vector3 velocity, float dampingRatio, float angularFrequency) {
			velocity += -2.0f * Time.deltaTime * dampingRatio * angularFrequency * velocity + Time.deltaTime * angularFrequency * angularFrequency * (targetValue - currentValue);
			currentValue += Time.deltaTime * velocity;

			return currentValue;
		}


		/// <summary>
		/// uses the implicit euler method. faster, but not always stable.
		/// see http://allenchou.net/2015/04/game-math-more-on-numeric-springing/
		/// </summary>
		/// <returns>The spring.</returns>
		/// <param name="currentValue">Current value.</param>
		/// <param name="targetValue">Target value.</param>
		/// <param name="velocity">Velocity by reference. Be sure to reset it to 0 if changing the targetValue between calls</param>
		/// <param name="dampingRatio">lower values are less damped and higher values are more damped resulting in less springiness.
		/// should be between 0.01f, 1f to avoid unstable systems.</param>
		/// <param name="angularFrequency">An angular frequency of 2pi (radians per second) means the oscillation completes one
		/// full period over one second, i.e. 1Hz. should be less than 35 or so to remain stable</param>
		public static Vector3 StableSpring(Vector3 currentValue, Vector3 targetValue, ref Vector3 velocity, float dampingRatio, float angularFrequency) {
			var f = 1f + 2f * Time.deltaTime * dampingRatio * angularFrequency;
			var oo = angularFrequency * angularFrequency;
			var hoo = Time.deltaTime * oo;
			var hhoo = Time.deltaTime * hoo;
			var detInv = 1.0f / (f + hhoo);
			var detX = f * currentValue + Time.deltaTime * velocity + hhoo * targetValue;
			var detV = velocity + hoo * (targetValue - currentValue);

			currentValue = detX * detInv;
			velocity = detV * detInv;

			return currentValue;
		}
	}
}