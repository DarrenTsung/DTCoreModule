using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public class BurnShaderRIC2D : RendererInstanceComponent2D {
		// PRAGMA MARK - INTERFACE
		public Texture2D DissolveMap {
			get { return _dissolveMap; }
			set { 
				_dissolveMap = value;
				this.MaterialInstance.SetTexture("_DissolveMap", _dissolveMap); 
			}
		}
		
		public float DissolveAmount {
			get { return _dissolveAmount; } 
			set {
				_dissolveAmount = value;
				this.MaterialInstance.SetFloat("_DissolveAmount", _dissolveAmount); 
			}
		}
		
		public Texture2D BurnRampTexture {
			get { return _burnRampTexture; }
			set { 
				_burnRampTexture = value;
				this.MaterialInstance.SetTexture("_BurnRampTex", _burnRampTexture); 
			}
		}
		
		public float BurnRampScale {
			get { return _burnRampScale; } 
			set {
				_burnRampScale = value;
				this.MaterialInstance.SetFloat("_BurnRampScale", _burnRampScale); 
			}
		}
			
		// PRAGMA MARK - INTERNAL
		[SerializeField]
		protected Texture2D _dissolveMap;
		[SerializeField]
		protected float _dissolveAmount;
		[SerializeField]
		protected Texture2D _burnRampTexture;
		[SerializeField]
		protected float _burnRampScale;
		
		protected override string ShaderName() {
			return "Sprites/Default-BurnShader";
		}
	}
}