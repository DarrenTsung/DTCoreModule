using UnityEngine;
using System.Collections;
using System;


namespace DT {
	/// <summary>
	/// makes any method have a button in the inspector to call it
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.Method)]
	public class MakeButtonAttribute : Attribute {}

	/// <summary>
	/// adds a vector2/3 editor to the scene GUI if this attribute is on any serialized Vector2/3, List<Vector2/3>
	/// or Vector2/3[] fields.
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.Field)]
	public class VectorInspectable : Attribute {}

	/// <summary>
	/// adds a local vector2/3 editor to the scene GUI if this attribute is on any serialized Vector2/3, List<Vector2/3>
	/// or Vector2/3[] fields.
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.Field)]
	public class LocalVectorInspectable : Attribute {}
}