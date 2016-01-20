using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DT {
  public static class IStringSerializableUtil {
    public static void WriteToTextSource(IStringSerializable s, TextAsset source) {
      if (source == null) {
        Debug.LogWarning("WriteToTextSource: failed to write because source is null!");
        return;
      }

#if UNITY_EDITOR
      string assetPath = AssetDatabase.GetAssetPath(source);
      File.WriteAllText(Application.dataPath +  assetPath.Replace("Assets", ""), s.SerializeToString());
      AssetDatabase.SaveAssets();
      AssetDatabase.Refresh();
#endif
    }
  }
}