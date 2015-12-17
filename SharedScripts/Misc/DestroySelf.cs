using UnityEngine;

namespace DT {
	public class DestroySelf : MonoBehaviour {
		// PRAGMA MARK - Internal
		[SerializeField]
		protected float _delay = 0.0f;
		
		protected void Awake() {
			GameObject.Destroy(gameObject, _delay);
		}
	}
}