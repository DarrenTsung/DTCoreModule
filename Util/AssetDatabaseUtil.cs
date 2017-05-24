#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT {
	public class ClearCachedAssetsOnPostProcess : AssetPostprocessor {
		private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
			AssetDatabaseUtil.ClearCachedAssets();
		}
	}

	public static class AssetDatabaseUtil {
		public static void ClearCachedAssets() {
			_cachedAssets.Clear();
		}

		public static List<T> AllAssetsOfType<T>() where T : UnityEngine.Object {
			var type = typeof(T);
			if (!_cachedAssets.ContainsKey(type)) {
				List<T> assets = new List<T>();

				var guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
				foreach (string guid in guids) {
					var asset = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));
					if (asset == null) {
						continue;
					}

					assets.Add(asset);
				}

				_cachedAssets[type] = assets;
			}

			return (List<T>)_cachedAssets[type];
		}

		public static string[] FindAssetsMatchingFilename(string filename) {
			string[] guids = AssetDatabase.FindAssets(filename);

			// filter by exact filename
			guids = guids.Where((string guid) => {
				string path = AssetDatabase.GUIDToAssetPath(guid);
				return Path.GetFileNameWithoutExtension(path) == filename;
				}).ToArray();

				return guids;
			}

			public static T LoadAssetAtPath<T>(string assetPath) where T : class {
				return AssetDatabase.LoadAssetAtPath(assetPath, typeof(T)) as T;
			}

			public static string FindSpecificAsset(string findAssetsInput) {
				string[] guids = AssetDatabase.FindAssets(findAssetsInput);

				if (guids.Length <= 0) {
					Debug.LogError(string.Format("FindSpecificAsset: Can't find anything matching ({0}) anywhere in the project", findAssetsInput));
					return "";
				}

				if (guids.Length > 2) {
					Debug.LogError(string.Format("FindSpecificAsset: More than one file found for ({0}) in the project!", findAssetsInput));
					return "";
				}

				return guids[0];
			}


			private static Dictionary<Type, object> _cachedAssets = new Dictionary<Type, object>();
		}
	}
	#endif