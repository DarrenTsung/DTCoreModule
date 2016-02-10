using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DT {
  public static class TextAssetUtil {
    public static void WriteToTextAsset(string serializedString, TextAsset source) {
      if (source == null) {
        Debug.LogWarning("WriteToTextAsset: failed to write because source is null!");
        return;
      }

#if UNITY_EDITOR
      string assetPath = AssetDatabase.GetAssetPath(source);
      File.WriteAllText(Application.dataPath +  assetPath.Replace("Assets", ""), serializedString);
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();
#endif
    }
  }
}