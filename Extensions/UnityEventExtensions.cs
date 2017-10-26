using UnityEngine;
using UnityEngine.Events;

namespace UnityEvents {
	[System.Serializable]
	public class F : UnityEvent<float> { }

	[System.Serializable]
	public class I : UnityEvent<int> { }

	[System.Serializable]
	public class S : UnityEvent<string> { }

	[System.Serializable]
	public class B : UnityEvent<bool> { }

	[System.Serializable]
	public class V2 : UnityEvent<Vector2> { }

	[System.Serializable]
	public class V3 : UnityEvent<Vector3> { }

	[System.Serializable]
	public class O : UnityEvent<object> { }

	[System.Serializable]
	public class G : UnityEvent<GameObject> { }

	[System.Serializable]
	public class FF : UnityEvent<float, float> { }

	[System.Serializable]
	public class FI : UnityEvent<float, int> { }

	[System.Serializable]
	public class FS : UnityEvent<float, string> { }

	[System.Serializable]
	public class FB : UnityEvent<float, bool> { }

	[System.Serializable]
	public class FO : UnityEvent<float, object> { }

	[System.Serializable]
	public class IF : UnityEvent<int, float> { }

	[System.Serializable]
	public class II : UnityEvent<int, int> { }

	[System.Serializable]
	public class IS : UnityEvent<int, string> { }

	[System.Serializable]
	public class IB : UnityEvent<int, bool> { }

	[System.Serializable]
	public class IO : UnityEvent<int, object> { }

	[System.Serializable]
	public class IG : UnityEvent<int, GameObject> { }

	[System.Serializable]
	public class IV2 : UnityEvent<int, Vector2> { }

	[System.Serializable]
	public class IV3 : UnityEvent<int, Vector3> { }

	[System.Serializable]
	public class SF : UnityEvent<string, float> { }

	[System.Serializable]
	public class SI : UnityEvent<string, int> { }

	[System.Serializable]
	public class SS : UnityEvent<string, string> { }

	[System.Serializable]
	public class SB : UnityEvent<string, bool> { }

	[System.Serializable]
	public class SO : UnityEvent<string, object> { }

	[System.Serializable]
	public class BF : UnityEvent<bool, float> { }

	[System.Serializable]
	public class BI : UnityEvent<bool, int> { }

	[System.Serializable]
	public class BS : UnityEvent<bool, string> { }

	[System.Serializable]
	public class BB : UnityEvent<bool, bool> { }

	[System.Serializable]
	public class BO : UnityEvent<bool, object> { }

	[System.Serializable]
	public class OF : UnityEvent<object, float> { }

	[System.Serializable]
	public class OI : UnityEvent<object, int> { }

	[System.Serializable]
	public class OS : UnityEvent<object, string> { }

	[System.Serializable]
	public class OB : UnityEvent<object, bool> { }

	[System.Serializable]
	public class OO : UnityEvent<object, object> { }
}