using DT;
﻿using DT.GameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// Modified toolbox - http://wiki.unity3d.com/index.php/Toolbox
/// Instead of being able to add components, it checks if the dependancy is fulfilled
/// This is so we can query for a MonoBehaviour that has an inheritance subclass
/// Without knowing about the subclass
///
/// This requires someone to setup the composition root (Toolbox game object)
/// in the scene
namespace DT {
	public class Toolbox : Singleton<Toolbox> {
		protected Toolbox() {}
		
		// PRAGMA MARK - Interface
		static public T GetInstance<T>() where T : class {
			return Instance.GetComponentInstance<T>();
		}
			
		public T GetComponentInstance<T>() where T : class {
			return this.GetCachedComponent<T>(_cachedComponentMap);
		}
		
	  // PRAGMA MARK - Internal 
		protected Dictionary<Type, MonoBehaviour> _cachedComponentMap = new Dictionary<Type, MonoBehaviour>();
	}
}