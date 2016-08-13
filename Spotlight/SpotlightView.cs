using System;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;
﻿using UnityEngine.UI;

namespace DT {
	public class SpotlightView : MonoBehaviour, IRecycleCleanupSubscriber, IRecycleSetupSubscriber {
    private const float kFadeInOutTime = 0.7f;

    // PRAGMA MARK - Public Interface
    public void AnimateOutAndRecycle() {
      CoroutineWrapper.DoEaseEveryFrameForDuration(kFadeInOutTime, EaseType.QuadIn, (float p) => {
        this._rawImage.material.SetColor("_Color", new Color(0.0f, 0.0f, 0.0f, 1.0f - p));
      }, () => {
        ObjectPoolManager.Recycle(this);
      });
    }


    // PRAGMA MARK - IRecycleSetupSubscriber Implementation
    public void OnRecycleSetup() {
      this._rawImage.texture = SpotlightManager.RenderTexture;
      SpotlightManager.OnRenderTextureRecreated += this.HandleSpotlightRenderTextureRecreated;

      CoroutineWrapper.DoEaseEveryFrameForDuration(kFadeInOutTime, EaseType.QuadOut, (float p) => {
        this._rawImage.material.SetColor("_Color", new Color(0.0f, 0.0f, 0.0f, p));
      });
    }


    // PRAGMA MARK - IRecycleCleanupSubscriber Implementation
    public void OnRecycleCleanup() {
      this._rawImage.color = Color.clear;
      SpotlightManager.OnRenderTextureRecreated -= this.HandleSpotlightRenderTextureRecreated;
    }


    // PRAGMA MARK - Internal
    [SerializeField] private RawImage _rawImage;

    void OnDestroy() {
      this._rawImage.material.SetColor("_Color", Color.clear);
    }

    private void HandleSpotlightRenderTextureRecreated(RenderTexture texture) {
      this._rawImage.texture = texture;
    }
  }
}