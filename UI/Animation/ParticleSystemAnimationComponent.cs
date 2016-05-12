using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DT {
  public class ParticleSystemAnimationComponent : MonoBehaviour {
    public bool emissionEnabled = false;
    public ParticleSystem particleSystem;

    private void Awake() {
      if (this.particleSystem == null) {
        this.particleSystem = this.GetRequiredComponent<ParticleSystem>();
      }
    }

    private void LateUpdate() {
      this.particleSystem.SetEmissionEnabled(this.emissionEnabled);
    }
  }
}