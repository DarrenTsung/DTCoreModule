using System.Collections;
using UnityEngine;

namespace DT {
  public static class LayerMaskExtensions {
    public static bool ContainsIndex(this LayerMask layerMask, int layerIndex) {
      return layerMask == (layerMask.value | (1 << layerIndex));
    }
  }
}
