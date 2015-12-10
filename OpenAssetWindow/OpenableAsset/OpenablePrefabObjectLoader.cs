using System;
using System.Collections.Generic;
using UnityEditor;

namespace DT {
  public class OpenablePrefabObjectLoader : IOpenableObjectLoader {
    // PRAGMA MARK - IOpenableObjectLoader
    public IOpenableObject[] Load() {
			string[] guids = AssetDatabase.FindAssets("t:Prefab");
      
      List<IOpenableObject> objects = new List<IOpenableObject>();
      foreach (string guid in guids) {
        objects.Add(new OpenablePrefabObject(guid));
      }
      return objects.ToArray();
    }
  }
}