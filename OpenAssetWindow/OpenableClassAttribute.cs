using UnityEngine;
using System.Collections;
using System;

namespace DT {
	/// <summary>
	/// Marks a class to be searched for OpenableMethods
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.Class)]
	public class OpenableClassAttribute : Attribute {
  }
}