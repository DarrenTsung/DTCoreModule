using UnityEngine;

namespace DT {
  public static class ApplicationUtil {
    public static string PlatformAssetBundleString() {
      return ApplicationUtil.AssetBundleStringFor(Application.platform);
    }

    public static string AssetBundleStringFor(RuntimePlatform platform) {
      switch (platform) {
        case RuntimePlatform.OSXEditor:
          return "Editor";
        case RuntimePlatform.IPhonePlayer:
          return "IPhone";
        case RuntimePlatform.Android:
          return "Android";
        default:
          Debug.LogError("Using AssetBundleStringFor for an unsupported platform - " + platform);
          return "";
      }
    }

    public static string ProjectPath {
      get { return ApplicationUtil._projectPath; }
    }


    // PRAGMA MARK - Internal
    private static string _projectPath = Application.dataPath.Replace("/Assets", "");
  }
}