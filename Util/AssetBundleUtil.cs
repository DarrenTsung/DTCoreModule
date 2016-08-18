using UnityEditor;
using UnityEngine;

public class AssetBundleUtil {
  [MenuItem("DarrenTsung/Build AssetBundles To Streaming Assets")]
  static void BuildAllAssetBundles() {
    AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
    if (manifest == null) {
      Debug.LogError("Failed to build asset bundle, does Assets/StreamingAssets exist?");
    }
  }
}