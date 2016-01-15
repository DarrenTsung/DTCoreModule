#if UNITY_EDITOR
using System;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
  public static class AssetDatabaseUtil {
    public static string FindSpecificAsset(string findAssetsInput) {
			string[] guids = AssetDatabase.FindAssets(findAssetsInput);

			if (guids.Length <= 0) {
				throw new Exception(string.Format("FindSpecificAsset: Can't find anything matching ({0}) anywhere in the project", findAssetsInput));
			}

			if (guids.Length > 2) {
				throw new Exception(string.Format("FindSpecificAsset: More than one file found for ({0}) in the project!", findAssetsInput));
			}

      return guids[0];
    }
  }
}
#endif