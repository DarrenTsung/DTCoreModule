using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DT.ObjectPools {
	public class ObjectPool<T> where T : MonoBehaviour, IPoolableObject {
		protected List<T> _objectPool;
		[SerializeField]
		protected T _factoryObject;
		protected GameObject _manager;
		
		public ObjectPool(GameObject manager, T factoryObject) {
			_manager = manager;
			_factoryObject = factoryObject;
			
			_objectPool = new List<T>();
		}
		
		public T GetUnusedObject() {
			foreach (T obj in _objectPool) {
				if (!obj.IsActive()) {
					obj.SetActive();
					return obj;
				}
			}
			
			return MakeNewObject();
		}
		
		public List<T> CurrentlyActiveObjects() {
			List<T> activeObjects = new List<T>();
			foreach (T obj in _objectPool) {
				if (obj.IsActive()) {
					activeObjects.Add(obj);
				}
			}
			return activeObjects;
		}
		
		protected T MakeNewObject() {
			T newObject = Object.Instantiate(_factoryObject);
			newObject.gameObject.transform.parent = _manager.transform;
			_objectPool.Add(newObject);
			return newObject;
		}
	}
}