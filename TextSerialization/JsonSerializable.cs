using System;
using UnityEngine;

namespace DT {
  public static class JsonSerializable {
    public static T DeserializeFromTextAsset<T>(TextAsset source) {
      return JsonSerializable.DeserializeFromString<T>(source.text);
    }

    public static T DeserializeFromString<T>(string source) {
      return JsonUtility.FromJson<T>(source);
    }

    public static void OverwriteDeserializeFromTextAsset(TextAsset source, object objectToOverwrite) {
      JsonSerializable.OverwriteDeserializeFromString(source.text, objectToOverwrite);
    }

    public static void OverwriteDeserializeFromString(string source, object objectToOverwrite) {
      JsonUtility.FromJsonOverwrite(source, objectToOverwrite);
    }

    public static void SerializeToTextAsset(object obj, TextAsset source) {
      TextAssetUtil.WriteToTextAsset(JsonUtility.ToJson(obj), source);
    }
  }
}