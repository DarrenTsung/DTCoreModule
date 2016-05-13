using System.Collections;

namespace DT {
  public static class SingletonUtil<T> where T : new() {
    private static object _lock = new object();
    private static T _instance;

    public static T Instance {
      get {
				lock (SingletonUtil<T>._lock) {
          if (SingletonUtil<T>._instance == null) {
            SingletonUtil<T>._instance = new T();
          }
          return SingletonUtil<T>._instance;
				}
      }
    }
  }
}