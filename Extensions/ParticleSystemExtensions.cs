using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DT {
	public static class ParticleSystemExtensions {
		public static void SetEmissionEnabled(this ParticleSystem particleSystem, bool enabled) {
			ParticleSystem.EmissionModule em = particleSystem.emission;
			em.enabled = enabled;
		}

		public static void SetEmissionRateOverTime(this ParticleSystem particleSystem, float rateOverTime) {
			ParticleSystem.EmissionModule em = particleSystem.emission;
			em.rateOverTime = rateOverTime;
		}
	}
}
