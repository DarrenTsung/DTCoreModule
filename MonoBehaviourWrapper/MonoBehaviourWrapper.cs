using DTCommandPalette;
using System;
using UnityEngine;

namespace DT {
	public static class MonoBehaviourWrapper {
		static MonoBehaviourWrapper() {
			UnityHelper.Instance.Initialize();
		}

		public static event Action OnUpdate = delegate { };
		public static event Action OnFixedUpdate = delegate { };
		public static event Action OnApplicationPaused = delegate { };
		public static event Action OnApplicationResumed = delegate { };
		public static event Action OnApplicationQuit = delegate { };

		private class UnityHelper : Singleton<UnityHelper> {
			// PRAGMA MARK - Public Interface
			[RuntimeInitializeOnLoadMethod]
			public void Initialize() {
				// empty function so that MonoBehaviour will be created
			}

			private void Update() {
				OnUpdate.Invoke();
			}

			private void FixedUpdate() {
				OnFixedUpdate.Invoke();
			}

			private void OnApplicationPause(bool paused) {
				if (paused) {
					OnApplicationPaused.Invoke();
				} else {
					OnApplicationResumed.Invoke();
				}
			}

			private void OnApplicationQuit() {
				MonoBehaviourWrapper.OnApplicationQuit.Invoke();
			}
		}
	}
}