using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DT {
  public static class PersistentDataUtil {
    public static IFormatter formatter = new BinaryFormatter();

    public static T Load<T>(string directoryPath, string filename, Func<T> defaultProvider) {
      directoryPath = Path.Combine(Application.persistentDataPath, directoryPath);
      PersistentDataUtil.CreateDirectoryIfNecessary(directoryPath);

      string filepath = Path.Combine(directoryPath, filename);
      if (!File.Exists(filepath)) {
        FileStream file = File.Create(filepath);

        T defaultValue = defaultProvider.Invoke();

        PersistentDataUtil.formatter.Serialize(file, defaultValue);
        file.Close();
      }

      FileStream openedFile = File.Open(filepath, FileMode.Open);
      T openedValue = (T)PersistentDataUtil.formatter.Deserialize(openedFile);
      openedFile.Close();

      return openedValue;
    }

    public static void Save(string directoryPath, string filename, object objectToSerialize) {
      directoryPath = Path.Combine(Application.persistentDataPath, directoryPath);
      PersistentDataUtil.CreateDirectoryIfNecessary(directoryPath);

      string filepath = Path.Combine(directoryPath, filename);

      FileStream file = File.Create(filepath);
      PersistentDataUtil.formatter.Serialize(file, objectToSerialize);
      file.Close();
    }

    private static void CreateDirectoryIfNecessary(string directoryPath) {
      if (Directory.Exists(directoryPath)) {
        return;
      }

      string[] tokenizedDirectoryPath = PersistentDataUtil.TokenizeDirectory(directoryPath);
      PersistentDataUtil.CreateDirectoriesIfNecessary(tokenizedDirectoryPath);
    }

    private static void CreateDirectoriesIfNecessary(string[] tokenizedDirectoryPath) {
      string pathSoFar = "";
      for (int i = 0; i < tokenizedDirectoryPath.Length; i++) {
        string token = tokenizedDirectoryPath[i];
        if (token.IsNullOrEmpty()) {
          token = "/";
        }

        pathSoFar = Path.Combine(pathSoFar, token);

        if (!Directory.Exists(pathSoFar)) {
          Directory.CreateDirectory(pathSoFar);
        }
      }
    }

    private static string[] TokenizeDirectory(string directoryPath) {
      char[] separators = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
      return directoryPath.Split(separators);
    }
  }
}