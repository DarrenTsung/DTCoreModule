using System.Collections;

namespace DT {
	public static class SingletonUtil<T> where T : new() {
		private static object lock_ = new object();
		private static T instance_;

		public static T Instance {
			get {
				lock (SingletonUtil<T>.lock_) {
					if (SingletonUtil<T>.instance_ == null) {
						SingletonUtil<T>.instance_ = new T();
					}
					return SingletonUtil<T>.instance_;
				}
			}
		}
	}
}