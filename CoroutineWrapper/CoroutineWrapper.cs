using System;
using System.Collections;
using UnityEngine;

namespace DT {
	public partial class CoroutineWrapper {
		// PRAGMA MARK - Static
		public static CoroutineWrapper StartCoroutine(IEnumerator coroutine, Action finishedCallback) {
			return new CoroutineWrapper(coroutine, finishedCallback);
		}

		public static CoroutineWrapper StartCoroutine(IEnumerator coroutine, Action<bool> finishedCallback = null) {
			return new CoroutineWrapper(coroutine, finishedCallback);
		}

		public static CoroutineWrapper DoAfterRealtimeDelay(float delay, Action finishedCallback) {
			return StartCoroutine(RealtimeDelayCoroutine(delay), finishedCallback);
		}

		public static CoroutineWrapper DoAfterDelay(float delay, Action finishedCallback) {
			return StartCoroutine(DelayCoroutine(delay), finishedCallback);
		}

		public static CoroutineWrapper DoAfterFrame(Action finishedCallback) {
			return StartCoroutine(WaitOneFrameCoroutine(), finishedCallback);
		}

		public static CoroutineWrapper DoAtEndOfFrame(Action finishedCallback) {
			return StartCoroutine(EndOfFrameCoroutine(), finishedCallback);
		}

		public static CoroutineWrapper DoLerpFor(float duration, Action<float> lerpCallback, Action finishedCallback = null) {
			return StartCoroutine(DoLerpCoroutine(duration, lerpCallback), finishedCallback);
		}


		private static CoroutineRunner coroutineRunner_;

		[RuntimeInitializeOnLoadMethod]
		private static void Initialize() {
			GameObject coroutineRunnerObject = new GameObject("CoroutineRunner (DontDestroyOnLoad)");
			coroutineRunner_ = coroutineRunnerObject.AddComponent<CoroutineRunner>();
			GameObject.DontDestroyOnLoad(coroutineRunnerObject);
		}

		private static IEnumerator DoLerpCoroutine(float duration, Action<float> lerpCallback) {
			for (float time = 0.0f; time <= duration; time += Time.deltaTime) {
				lerpCallback.Invoke(time / duration);
				yield return null;
			}

			lerpCallback.Invoke(1.0f);
		}

		private static IEnumerator RealtimeDelayCoroutine(float delay) {
			yield return new WaitForSecondsRealtime(delay);
		}

		private static IEnumerator DelayCoroutine(float delay) {
			yield return new WaitForSeconds(delay);
		}

		private static readonly WaitForEndOfFrame kWaitForEndOfFrame = new WaitForEndOfFrame();
		private static IEnumerator EndOfFrameCoroutine() {
			yield return kWaitForEndOfFrame;
		}

		private static IEnumerator WaitOneFrameCoroutine() {
			yield return null;
		}


		// PRAGMA MARK - Public Interface
		public void Stop() {
			running_ = false;
			manuallyStopped_ = true;
		}

		public void Cancel() {
			running_ = false;
			cancelled_ = true;
		}


		// PRAGMA MARK - Internal
		private CoroutineWrapper(IEnumerator coroutine, Action finishedCallback) : this(coroutine) {
			finishedNoArgsCallback_ = finishedCallback;
		}

		private CoroutineWrapper(IEnumerator coroutine, Action<bool> finishedCallback) : this(coroutine) {
			finishedArgsCallback_ = finishedCallback;
		}

		private CoroutineWrapper(IEnumerator coroutine) {
			coroutine_ = coroutine;
			coroutineRunner_.StartCoroutine(Coroutine());
		}

		private Action finishedNoArgsCallback_;
		private Action<bool> finishedArgsCallback_;
		private IEnumerator coroutine_;

		private bool manuallyStopped_ = false;
		private bool running_ = true;
		private bool cancelled_ = false;

		private IEnumerator Coroutine() {
			while (running_) {
				if (coroutine_ != null && coroutine_.MoveNext()) {
					yield return coroutine_.Current;
				} else {
					running_ = false;
				}
			}

			if (!cancelled_ && finishedNoArgsCallback_ != null) {
				finishedNoArgsCallback_.Invoke();
			}

			if (!cancelled_ && finishedArgsCallback_ != null) {
				finishedArgsCallback_(manuallyStopped_);
			}
		}
	}
}