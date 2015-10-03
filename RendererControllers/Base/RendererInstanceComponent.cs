using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT {
	public class RendererInstanceComponent : MonoBehaviour {
		// PRAGMA MARK - INTERNAL
		protected Renderer Renderer {
			get { 
				if (_renderer == null) {
					_renderer = this.GetComponent<Renderer>(); 
				}
				return _renderer;
			}
		}
		
		protected Material MaterialInstance {
			get {
				if (_material == null) {
					_material = new Material(Shader.Find(this.ShaderName()));
					this.Renderer.sharedMaterial = _material;
				}
				return _material;
			}
		}
		
		protected virtual string ShaderName() {
			return "Sprites/Default";
		}
		
		[SerializeField]
		protected Material _material;
		[SerializeField]
		protected Renderer _renderer;
	}
}