using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	[ExecuteInEditMode]
	public class PulseShaderRIC2D : RendererInstanceComponent2D {
		// PRAGMA MARK - INTERFACE 
		public bool Pulsing {
			get { return _pulsing; }
			set {
				_pulsing = value;
			}
		}
		
		// PRAGMA MARK - INTERNAL
		[SerializeField]
		public bool _pulsing;
		[SerializeField]
		protected float _pulseSpeed;
		
		[SerializeField]
		protected Color _pulseColor;
		[SerializeField]
		protected float _pulseColorPercentLerp;
		
		protected override string ShaderName() {
			return "Sprites/Default-PulseShader";
		}
		
		protected void Update() {
			this.MaterialInstance.SetInt("_Pulsing", (_pulsing) ? 1 : 0); 
			this.MaterialInstance.SetFloat("_PulseSpeed", _pulseSpeed); 
			this.MaterialInstance.SetColor("_PulseColor", _pulseColor);
			this.MaterialInstance.SetFloat("_PulseColorPercentLerp", _pulseColorPercentLerp);
		}
	}
}