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

    public static Bounds OrthographicBounds(this Camera camera) {
      if (!camera.orthographic) {
        Debug.LogError("OrthographicBounds - called on camera that is not orthographic! " + camera);
        return default(Bounds);
      }

      float screenAspectRatio = (float)Screen.width / (float)Screen.height;
      float cameraHeight = camera.orthographicSize * 2;
      return new Bounds(camera.transform.position, new Vector3(cameraHeight * screenAspectRatio, cameraHeight, 0));
    }
  }
}
