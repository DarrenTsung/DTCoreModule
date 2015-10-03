using UnityEngine;
using System.Collections;

namespace DT.ObjectPools {
	public interface IPoolableObject {
		bool IsActive();
		void SetActive();
	}
}
