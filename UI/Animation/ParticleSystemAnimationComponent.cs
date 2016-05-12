using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DT {
  public class ParticleSystemAnimationComponent : MonoBehaviour {
    // PRAGMA MARK - Outlets
    public bool emissionEnabled = false;

    // PRAGMA MARK - Internal
    private ParticleSystem _particleSystem;

    private void Awake() {
      this._particleSystem = this.GetRequiredComponent<ParticleSystem>();
    }

    private void LateUpdate() {
      this._particleSystem.SetEmissionEnabled(this.emissionEnabled);
    }
  }
}