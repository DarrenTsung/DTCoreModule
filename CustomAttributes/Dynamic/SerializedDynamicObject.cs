using System;
using UnityEngine;

namespace DT {
  [Serializable]
  public class SerializedDynamicObject<T> where T : class {
    public string implementationTypeName;
    public string serializedDynamicObject;

    public T DynamicObject {
      get {
        if (this._cachedDynamicObject == null) {
          this._cachedDynamicObject = JsonSerialization.DeserializeGeneric<T>(this.serializedDynamicObject);
        }

        return this._cachedDynamicObject;
      }
    }

    public SerializedDynamicObject() {}


    private T _cachedDynamicObject;
  }
}