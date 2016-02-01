using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DT {
	public class ObjectPoolManager : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public GameObject Instantiate(string prefabName, GameObject parent = null) {
			GameObject instantiatedPrefab = this.GetGameObjectForPrefabName(prefabName);

			if (parent != null) {
				instantiatedPrefab.transform.SetParent(parent.transform);
			}

			RecyclablePrefab recycleData = instantiatedPrefab.GetOrAddComponent<RecyclablePrefab>();
      recycleData.Setup();

			return instantiatedPrefab;
		}

		public void Recycle(GameObject usedObject) {
			if (usedObject == null) {
				Debug.LogError("Recycle: called on null object!");
				return;
			}

			RecyclablePrefab recycleData = usedObject.GetComponent<RecyclablePrefab>();
			if (recycleData == null) {
				Debug.LogError("Recycle: usedObject - (" + usedObject + ") does not have RecyclablePrefab script!");
				return;
			}

      recycleData.Cleanup();
			usedObject.transform.SetParent(this.transform);
			usedObject.SetActive(false);

      Stack<GameObject> recycledObjects = this.ObjectPoolForPrefabName(recycleData.prefabName);
      recycledObjects.Push(usedObject);
		}


		// PRAGMA MARK - Internal
		private Dictionary<string, Stack<GameObject>> _objectPools = new Dictionary<string, Stack<GameObject>>();

		private Stack<GameObject> ObjectPoolForPrefabName(string prefabName) {
			return this._objectPools.GetAndCreateIfNotFound(prefabName);
		}

		private GameObject GetGameObjectForPrefabName(string prefabName) {
			Stack<GameObject> recycledObjects = this.ObjectPoolForPrefabName(prefabName);

			// try to find a recycled object that is usable
			while (recycledObjects.Count > 0) {
				GameObject recycledObj = recycledObjects.Pop();

				if (recycledObj != null) {
					if (!this.ValidateRecycledObject(recycledObj, prefabName)) {
						return null;
					}

					recycledObj.SetActive(true);
					return recycledObj;
				}
			}

			// if no recycled object is found, instantiate one
			GameObject prefab = PrefabList.PrefabForName(prefabName);
			if (prefab == null) {
				return null;
			}

			GameObject instantiatedPrefab = Object.Instantiate(prefab) as GameObject;

			RecyclablePrefab recycleData = instantiatedPrefab.GetOrAddComponent<RecyclablePrefab>();
			recycleData.prefabName = prefabName;

			return instantiatedPrefab;
		}

		private bool ValidateRecycledObject(GameObject recycledObject, string prefabName) {
			if (recycledObject.activeSelf) {
				Debug.LogError("GetGameObjectForPrefabName: recycled object: (" + recycledObject + ") is still active, did something go wrong?");
				return false;
			}

			RecyclablePrefab recycleData = recycledObject.GetComponent<RecyclablePrefab>();
			if (recycleData == null) {
				Debug.LogError("GetGameObjectForPrefabName: recycled object: (" + recycledObject + ") doesn't have a recyclable prefab script!");
				return false;
			}

			if (recycleData.prefabName != prefabName) {
				Debug.LogError("GetGameObjectForPrefabName: recycled object: (" + recycledObject + ") doesn't match prefab name: " + prefabName + "!");
				return false;
			}

			return true;
		}
	}
}