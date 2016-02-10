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

    public static void SerializeToTextAsset(object obj, TextAsset source) {
      TextAssetUtil.WriteToTextAsset(JsonUtility.ToJson(obj), source);
    }
  }
}