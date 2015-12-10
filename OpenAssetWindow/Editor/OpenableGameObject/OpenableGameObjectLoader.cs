using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DT {
  public abstract class OpenableGameObjectLoader : IOpenableObjectLoader {
    // PRAGMA MARK - IOpenableObjectLoader
    public IOpenableObject[] Load() {
      GameObject[] gameObjects = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
    
      List<IOpenableObject> objects = new List<IOpenableObject>();
      foreach (GameObject obj in gameObjects) {
        objects.Add(this.MakeOpenableGameObject(obj));
      }
      return objects.ToArray();
    }
    
    protected abstract IOpenableObject MakeOpenableGameObject(GameObject obj);
  }
}