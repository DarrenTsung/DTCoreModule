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
	}
}
