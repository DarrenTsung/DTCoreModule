#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace DT {
  [OpenableClass]
  public class OpenableEditorUtil {
    [OpenableMethod]
    public static void Quit() {
      if (!EditorApplication.isPlaying) {
        return;
      }

      EditorApplication.isPlaying = false;
    }

    [OpenableMethod]
    public static void Play() {
      if (EditorApplication.isPlaying) {
        return;
      }

      EditorApplication.isPlaying = true;
    }

    [OpenableMethod]
    public static void CreateTopLevelEmptyChild() {
      GameObject newObject = new GameObject();
      Selection.activeGameObject = newObject;
    }

    [OpenableMethod]
    public static void DeletePersistentData() {
      if (Application.isPlaying) {
        Debug.Log("Won't delete persistent data because the application is playing!");
        return;
      }

      DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
      dataDir.Delete(recursive: true);
      Debug.Log("Successfully deleted persistent data!");
    }

    [OpenableMethod]
    public static void DeletePlayerPrefs() {
      if (Application.isPlaying) {
        Debug.Log("Won't delete player prefs because the application is playing!");
        return;
      }

      PlayerPrefs.DeleteAll();
      Debug.Log("Successfully deleted player prefs!");
    }
  }
}
#endif