using System;
using UnityEngine;

namespace DT {
  public class JsonSerializable : IStringSerializable {
    public static T DeserializeFromTextAsset<T>(TextAsset source) where T : JsonSerializable {
      return JsonSerializable.DeserializeFromString<T>(source.text);
    }

    public static T DeserializeFromString<T>(string source) where T : JsonSerializable {
      return JsonUtility.FromJson<T>(source);
    }

    // PRAGMA MARK - IStringSerializable implementation
    public string SerializeToString() {
      return JsonUtility.ToJson(this);
    }
  }
}