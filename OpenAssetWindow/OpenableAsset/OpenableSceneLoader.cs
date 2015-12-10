using System;
using System.Collections.Generic;
using UnityEditor;

namespace DT {
  public class OpenableSceneObjectLoader : IOpenableObjectLoader {
    // PRAGMA MARK - IOpenableObjectLoader
    public IOpenableObject[] Load() {
			string[] guids = AssetDatabase.FindAssets("t:Scene");
      
      List<IOpenableObject> objects = new List<IOpenableObject>();
      foreach (string guid in guids) {
        objects.Add(new OpenableSceneObject(guid));
      }
      return objects.ToArray();
    }
  }
}