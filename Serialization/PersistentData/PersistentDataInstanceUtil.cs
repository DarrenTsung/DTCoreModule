using DT;
using System;
using UnityEngine;

namespace DT.Game {
  public static class PersistentDataInstanceUtil<T> {
    public static Func<string> DirectoryPathProvider = PersistentDataInstanceUtil<T>.DefaultDirectoryPathProvider;
    public static Func<string> FilenameProvider = PersistentDataInstanceUtil<T>.DefaultFilenameProvider;
    public static Func<T> DefaultInstanceProvider;

    private static T _instance;
    private static object _lock = new object();
    private static bool _instanceDirtied;

    public static T Instance {
      get {
        lock (_lock) {
          if (PersistentDataInstanceUtil<T>._instance == null) {
            PersistentDataInstanceUtil<T>._instance = PersistentDataInstanceUtil<T>.Load();
          }

          return PersistentDataInstanceUtil<T>._instance;
        }
      }
    }

    public static void DirtyInstance() {
      _instanceDirtied = true;
      // TODO (darren): move this check to be checked every 30 seconds or something
      PersistentDataInstanceUtil<T>.SaveInstanceIfDirty();
    }

    private static void SaveInstanceIfDirty() {
      if (_instanceDirtied) {
        PersistentDataInstanceUtil<T>.Save();
        _instanceDirtied = false;
      }
    }

    private static void Save() {
      string directoryPath = PersistentDataInstanceUtil<T>.DirectoryPathProvider.Invoke();
      string filename = PersistentDataInstanceUtil<T>.FilenameProvider.Invoke();

      PersistentDataUtil.Save(directoryPath, filename, PersistentDataInstanceUtil<T>._instance);
    }

    private static T Load() {
      string directoryPath = PersistentDataInstanceUtil<T>.DirectoryPathProvider.Invoke();
      string filename = PersistentDataInstanceUtil<T>.FilenameProvider.Invoke();

      return PersistentDataUtil.Load<T>(directoryPath, filename, PersistentDataInstanceUtil<T>.DefaultInstanceProvider);
    }

    private static string DefaultFilenameProvider() {
      return typeof(T).Name;
    }

    private static string DefaultDirectoryPathProvider() {
      return "";
    }
  }
}