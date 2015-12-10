using System;
using UnityEngine;

namespace DT {
  public class SelectableGameObjectLoader : OpenableGameObjectLoader {
    protected override IOpenableObject MakeOpenableGameObject(GameObject obj) {
      return new SelectableGameObject(obj);
    }
  }
}