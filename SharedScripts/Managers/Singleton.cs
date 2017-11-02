using UnityEngine;

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
///
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>


namespace DT {
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
		private static T instance_;

		private static object lock_ = new object();

		public static T Instance {
			get {
				lock (lock_) {
					if (instance_ == null) {
						instance_ = (T)FindObjectOfType(typeof(T));

						if (Object.FindObjectsOfType(typeof(T)).Length > 1) {
							Debug.LogError("[Singleton] Something went really wrong " +
															   " - there should never be more than 1 singleton!" +
															   " Reopening the scene might fix it.");
							return instance_;
						}

						if (instance_ == null && Application.isPlaying) {
							GameObject singleton = new GameObject();
							instance_ = singleton.AddComponent<T>();
							singleton.name = "(singleton) " + typeof(T).ToString();

							GameObject.DontDestroyOnLoad(singleton);
						}
					}

					return instance_;
				}
			}
		}
	}
}