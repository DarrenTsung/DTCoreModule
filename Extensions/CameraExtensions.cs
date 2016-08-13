using System.Collections;
using UnityEngine;

namespace DT {
  public static class CameraExtensions {
    public static void RenderToTexture(this Camera c, RenderTexture texture) {
      if (!c.isActiveAndEnabled) {
        Debug.LogWarning("RenderToTexture - camera is not active and enabled!");
        return;
      }

      RenderTexture cachedTexture = c.targetTexture;

      c.targetTexture = texture;
      c.Render();

      c.targetTexture = cachedTexture;
    }
  }
}
