using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DT {
	public static class TextAssetUtil {
		private const string kResourcesPath = "Assets/GameSpecific/Resources";
		private const string kTextAssetsFolder = "TextAssets";
		private const string kFileExtension = ".txt";

		public static void WriteToTextAsset(string serializedString, TextAsset source) {
			if (source == null) {
				Debug.LogWarning("WriteToTextAsset: failed to write because source is null!");
				return;
			}

#if UNITY_EDITOR
			string assetPath = AssetDatabase.GetAssetPath(source);
			File.WriteAllText(Application.dataPath + assetPath.Replace("Assets", ""), serializedString);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
#endif
		}

		public static TextAsset GetOrCreateTextAsset(string filename) {
			TextAsset textAsset = Resources.Load(kTextAssetsFolder + "/" + filename) as TextAsset;
#if UNITY_EDITOR
			string textAssetFullPath = kResourcesPath + "/" + kTextAssetsFolder + "/" + filename + kFileExtension;

			if (textAsset == null) {
				if (!AssetDatabase.IsValidFolder(kResourcesPath + "/" + kTextAssetsFolder)) {
					AssetDatabase.CreateFolder(kResourcesPath, kTextAssetsFolder);
				}
				File.WriteAllText(textAssetFullPath, "");
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();

				textAsset = Resources.Load(kTextAssetsFolder + "/" + filename) as TextAsset;
			}
#endif

			if (textAsset == null) {
				Debug.LogError("Failed to find or create text asset for filename: " + filename);
				return new TextAsset();
			}

			return textAsset;
		}

		public static void WriteToTextAssetFilename(string serializedString, string filename) {
#if UNITY_EDITOR
			string textAssetFullPath = kResourcesPath + "/" + kTextAssetsFolder + "/" + filename + kFileExtension;
			File.WriteAllText(textAssetFullPath, serializedString);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
#endif
		}
	}
}