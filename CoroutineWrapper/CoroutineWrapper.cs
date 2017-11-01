using System;
using System.Collections;
using UnityEngine;

namespace DT {
	public partial class CoroutineWrapper {
		// PRAGMA MARK - Static
		public static CoroutineWrapper StartCoroutine(IEnumerator coroutine) {
			return new CoroutineWrapper(coroutine);
		}

		public static CoroutineWrapper DoAfterRealtimeDelay(float delay, Action finishedCallback) {
			return StartCoroutine(RealtimeDelayCoroutine(delay, finishedCallback));
		}

		public static CoroutineWrapper DoAfterDelay(float delay, Action finishedCallback) {
			return StartCoroutine(DelayCoroutine(delay, finishedCallback));
		}

		public static CoroutineWrapper DoEveryFrameForDelay(float delay, Action perFrameCallback, Action finishedCallback) {
			return StartCoroutine(DelayFrameCoroutine(delay, perFrameCallback, finishedCallback));
		}

		public static CoroutineWrapper DoAfterFrame(Action finishedCallback) {
			return StartCoroutine(WaitOneFrameCoroutine(finishedCallback));
		}

		public static CoroutineWrapper DoAtEndOfFrame(Action finishedCallback) {
			return StartCoroutine(EndOfFrameCoroutine(finishedCallback));
		}

		public static CoroutineWrapper DoLerpFor(float duration, Action<float> lerpCallback, Action finishedCallback = null) {
			return StartCoroutine(DoLerpCoroutine(duration, lerpCallback, finishedCallback));
		}


		private static CoroutineRunner coroutineRunner_;

		[RuntimeInitializeOnLoadMethod]
		private static void Initialize() {
			GameObject coroutineRunnerObject = new GameObject("CoroutineRunner (DontDestroyOnLoad)");
			coroutineRunner_ = coroutineRunnerObject.AddComponent<CoroutineRunner>();
			GameObject.DontDestroyOnLoad(coroutineRunnerObject);
		}

		private static IEnumerator DoLerpCoroutine(float duration, Action<float> lerpCallback, Action finishedCallback) {
			for (float time = 0.0f; time <= duration; time += Time.deltaTime) {
				lerpCallback.Invoke(time / duration);
				yield return null;
			}

			lerpCallback.Invoke(1.0f);
			if (finishedCallback != null) {
				finishedCallback.Invoke();
			}
		}

		private static IEnumerator RealtimeDelayCoroutine(float delay, Action finishedCallback) {
			yield return new WaitForSecondsRealtime(delay);
			finishedCallback.Invoke();
		}

		private static IEnumerator DelayCoroutine(float delay, Action finishedCallback) {
			yield return new WaitForSeconds(delay);
			finishedCallback.Invoke();
		}

		private static readonly WaitForEndOfFrame kWaitForEndOfFrame = new WaitForEndOfFrame();
		private static IEnumerator EndOfFrameCoroutine(Action finishedCallback) {
			yield return kWaitForEndOfFrame;
			finishedCallback.Invoke();
		}

		private static IEnumerator WaitOneFrameCoroutine(Action finishedCallback) {
			yield return null;
			finishedCallback.Invoke();
		}

		private static IEnumerator DelayFrameCoroutine(float delay, Action perFrameCallback, Action finishedCallback) {
			for (float time = 0.0f; time <= delay; time += Time.deltaTime) {
				perFrameCallback.Invoke();
				yield return null;
			}

			finishedCallback.Invoke();
		}


		// PRAGMA MARK - Public Interface
		public void Cancel() {
			coroutineRunner_.StopCoroutine(coroutine_);
		}


		// PRAGMA MARK - Internal
		private CoroutineWrapper(IEnumerator coroutine) {
			coroutine_ = coroutineRunner_.StartCoroutine(coroutine);
		}

		private Coroutine coroutine_;
	}
}