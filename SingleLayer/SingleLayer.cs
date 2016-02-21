using UnityEngine;

[System.Serializable]
public class SingleLayer {
  [SerializeField]
  private int _layerIndex = 0;
  public int LayerIndex {
    get { return this._layerIndex; }
  }

  public void Set(int layerIndex) {
    if (layerIndex > 0 && layerIndex < 32) {
      this._layerIndex = layerIndex;
    }
  }

  public int Mask {
    get { return 1 << this._layerIndex; }
  }
}