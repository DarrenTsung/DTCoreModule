using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT {
	public static class SpotlightManager {
    private const int kDownsizeFactor = 4;

    // PRAGMA MARK - Public Interface
    public static event Action<RenderTexture> OnRenderTextureRecreated = delegate {};

    public static void Initialize() {
      SpotlightManager._layerMask = LayerMask.GetMask(new string[] { "Spotlight" });
    }

    public static void ShowSpotlight() {
      if (SpotlightManager._spotlightView != null) {
        Debug.LogError("ShowSpotlight - already showing spotlight!");
        return;
      }

      if (SpotlightManager._spotlightGameObjects.Count <= 0) {
        Debug.LogWarning("ShowSpotlight - no spotlight game objects, probably not what you wanted!");
      }

      SpotlightManager.UpdateRenderTexture();

      SpotlightManager._spotlightView = ObjectPoolManager.Instantiate<SpotlightView>("SpotlightView");
      ViewManagerLocator.Main.AttachView(SpotlightManager._spotlightView);
    }

    public static void HideSpotlight() {
      if (SpotlightManager._spotlightView != null) {
        SpotlightManager._spotlightView.AnimateOutAndRecycle();
        SpotlightManager._spotlightView = null;
      }
    }

    public static void AddSpotlightGameObject(GameObject g) {
      if (!SpotlightManager._layerMask.ContainsIndex(g.layer)) {
        Debug.LogWarning("AddSpotlightGameObject - gameObject is not in the Spotlight layer! This is currently a requirement!");
        return;
      }

      if (SpotlightManager._spotlightGameObjects.Contains(g)) {
        Debug.LogWarning("AddSpotlightGameObject - gameObject is already in _spotlightGameObjects");
        return;
      }

      g.SetActive(false);
      SpotlightManager._spotlightGameObjects.Add(g);
    }

    public static void RemoveSpotlightGameObject(GameObject g) {
      SpotlightManager._spotlightGameObjects.Remove(g);
    }

    public static RenderTexture RenderTexture {
      get {
        if (SpotlightManager.ShouldRecreateRenderTexture()) {
          SpotlightManager._renderTexture = new RenderTexture(Screen.width / kDownsizeFactor,
                                                              Screen.height / kDownsizeFactor,
                                                              depth: 0,
                                                              format: RenderTextureFormat.ARGB4444);

          SpotlightManager._cachedScreenWidth = Screen.width;
          SpotlightManager._cachedScreenHeight = Screen.height;

          SpotlightManager.OnRenderTextureRecreated.Invoke(SpotlightManager._renderTexture);
        }

        return SpotlightManager._renderTexture;
      }
    }




    // PRAGMA MARK - Static Internal
    private static HashSet<GameObject> _spotlightGameObjects = new HashSet<GameObject>();
    private static LayerMask _layerMask;

    private static SpotlightView _spotlightView;

    private static RenderTexture _renderTexture;
    private static int _cachedScreenWidth;
    private static int _cachedScreenHeight;

    private static bool ShouldRecreateRenderTexture() {
      if (SpotlightManager._renderTexture == null) {
        return true;
      }

      if (SpotlightManager._cachedScreenWidth != Screen.width || SpotlightManager._cachedScreenHeight != Screen.height) {
        return true;
      }

      return false;
    }

    private static void UpdateRenderTexture() {
      Camera camera = Camera.main;

      // replace camera values
      int cachedCullingMask = camera.cullingMask;
      Color cachedBackgroundColor = camera.backgroundColor;
      CameraClearFlags cachedClearFlags = camera.clearFlags;

      camera.cullingMask = SpotlightManager._layerMask.value;
      camera.backgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
      camera.clearFlags = CameraClearFlags.Color;

      foreach (GameObject g in SpotlightManager._spotlightGameObjects) {
        g.SetActive(true);
      }

      camera.RenderToTexture(SpotlightManager.RenderTexture);

      foreach (GameObject g in SpotlightManager._spotlightGameObjects) {
        g.SetActive(false);
      }

      // restore old camera values
      camera.cullingMask = cachedCullingMask;
      camera.backgroundColor = cachedBackgroundColor;
      camera.clearFlags = cachedClearFlags;
    }
	}
}