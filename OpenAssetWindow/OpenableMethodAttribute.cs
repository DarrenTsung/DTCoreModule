using UnityEngine;
using System.Collections;
using System;

namespace DT {
	/// <summary>
	/// Marking a method with this attribute adds it to the list that the OpenAssetWindow queries from
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.Method)]
	public class OpenableMethodAttribute : Attribute {
    
  }
}