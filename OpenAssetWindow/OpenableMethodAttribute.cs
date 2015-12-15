using UnityEngine;
using System.Collections;
using System;

namespace DT {
	/// <summary>
	/// Marking a method with this attribute adds it to the list that the OpenAssetWindow queries from
	/// Only if the class is [OpenableClass]
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.Method)]
	public class OpenableMethodAttribute : Attribute {
    public OpenableMethodAttribute(string methodDisplayName) {
			this.methodDisplayName = methodDisplayName;
		}
		
		public OpenableMethodAttribute() {
			this.methodDisplayName = null;
		}
		
		public string methodDisplayName;
  }
}