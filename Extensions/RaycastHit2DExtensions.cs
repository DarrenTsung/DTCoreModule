using System.Collections;
using UnityEngine;

namespace DT {
  public static class RaycastHit2DExtensions {
    public static GameObject GameObject(this RaycastHit2D raycast) {
      return raycast.collider.gameObject;
    }
  }
}
