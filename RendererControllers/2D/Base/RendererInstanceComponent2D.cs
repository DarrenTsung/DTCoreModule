using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public class RendererInstanceComponent2D : RendererInstanceComponent {
		// PRAGMA MARK - INTERFACE
		public Texture2D MainTexture {
			get { return _texture; }
			set { 
				_texture = value;
				this.MaterialInstance.SetTexture("_MainTex", _texture); 
			}
		}
			
		// PRAGMA MARK - INTERNAL
		[SerializeField]
		protected Texture2D _texture;
	}
}