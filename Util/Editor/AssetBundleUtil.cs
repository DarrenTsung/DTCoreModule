using UnityEditor;
using UnityEngine;

namespace DT {
	public static class AssetBundleUtil {
		[MenuItem("DarrenTsung/Build AssetBundles To Streaming Assets")]
		private static void BuildAllAssetBundles() {
			BuildPipeline.BuildAssetBundles("Assets/StreamingAssets/" + ApplicationUtil.AssetBundleStringFor(RuntimePlatform.OSXEditor), BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
			BuildPipeline.BuildAssetBundles("Assets/StreamingAssets/" + ApplicationUtil.AssetBundleStringFor(RuntimePlatform.IPhonePlayer), BuildAssetBundleOptions.None, BuildTarget.iOS);
			BuildPipeline.BuildAssetBundles("Assets/StreamingAssets/" + ApplicationUtil.AssetBundleStringFor(RuntimePlatform.Android), BuildAssetBundleOptions.None, BuildTarget.Android);
		}
	}
}