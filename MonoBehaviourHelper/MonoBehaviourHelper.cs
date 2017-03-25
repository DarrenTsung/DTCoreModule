using DTCommandPalette;
using System;
using UnityEngine;

namespace DT {
    public static class MonoBehaviourHelper {
        public static event Action OnUpdate = delegate {};
        public static event Action OnFixedUpdate = delegate {};
        public static event Action OnApplicationPaused = delegate {};
        public static event Action OnApplicationResumed = delegate {};
        public static event Action OnApplicationQuit = delegate {};

        private class UnityHelper : Singleton<UnityHelper> {
            // PRAGMA MARK - Public Interface
            [RuntimeInitializeOnLoadMethod]
            public void Initialize() {
                // empty function so that MonoBehaviour will be created
            }

            void Update() {
                MonoBehaviourHelper.OnUpdate.Invoke();
            }

            void FixedUpdate() {
                MonoBehaviourHelper.OnFixedUpdate.Invoke();
            }

            void OnApplicationPause(bool paused) {
                if (paused) {
                    MonoBehaviourHelper.OnApplicationPaused.Invoke();
                } else {
                    MonoBehaviourHelper.OnApplicationResumed.Invoke();
                }
            }

            void OnApplicationQuit() {
                MonoBehaviourHelper.OnApplicationQuit.Invoke();
            }
        }
    }
}