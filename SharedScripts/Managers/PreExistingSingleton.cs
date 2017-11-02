using UnityEngine;

namespace DT {
	public class PreExistingSingleton<T> : MonoBehaviour where T : MonoBehaviour {
		private static T instance_;
		private static bool checked_ = false;

		private static object lock_ = new object();

		public static T Instance {
			get {
				lock (lock_) {
					if (instance_ == null && !checked_) {
						checked_ = true;
						instance_ = (T)FindObjectOfType(typeof(T));

						if (Object.FindObjectsOfType(typeof(T)).Length > 1) {
							Debug.LogError("[PreExistingSingleton] Something went really wrong " +
															   " - there should never be more than 1 singleton!" +
															   " Reopening the scene might fix it.");
							return instance_;
						}
					}

					return instance_;
				}
			}
		}
	}
}