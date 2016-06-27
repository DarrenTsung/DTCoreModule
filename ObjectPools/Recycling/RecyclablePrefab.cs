using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT {
  public class RecyclablePrefab : MonoBehaviour {
    public void Setup() {
      foreach (Renderer renderer in this._renderers) {
        renderer.enabled = true;
      }

      foreach (Canvas canvas in this._canvases) {
        canvas.enabled = true;
      }

      foreach (IRecycleSetupSubscriber subscriber in this._setupSubscribers) {
        subscriber.OnRecycleSetup();
      }
    }

    public void Cleanup() {
      foreach (Renderer renderer in this._renderers) {
        renderer.enabled = false;
      }

      foreach (Canvas canvas in this._canvases) {
        canvas.enabled = false;
      }

      foreach (IRecycleCleanupSubscriber subscriber in this._cleanupSubscribers) {
        subscriber.OnRecycleCleanup();
      }

      foreach (GameObject g in this._attachedChildRecycables) {
        ObjectPoolManager.Recycle(g);
      }
      this._attachedChildRecycables.Clear();
    }

    public void AttachChildRecyclableObject(GameObject child) {
      bool addedSuccessfully = this._attachedChildRecycables.Add(child);
      if (!addedSuccessfully) {
        Debug.LogWarning("AttachChildRecyclableObject - child already in attachedCleanupSubscribers!");
      }
    }

    public void DettachChildRecyclableObject(GameObject child) {
      bool successful = this._attachedChildRecycables.Remove(child);
      if (!successful) {
        Debug.LogWarning("DettachChildRecyclableObject - failed to find child in attachedCleanupSubscribers!");
      }
    }

    public string prefabName;

    // PRAGMA MARK - Internal
    private IRecycleSetupSubscriber[] _setupSubscribers;
    private IRecycleCleanupSubscriber[] _cleanupSubscribers;

    private HashSet<GameObject> _attachedChildRecycables = new HashSet<GameObject>();

    private Renderer[] _renderers;
    private Canvas[] _canvases;

    private void Awake() {
      this._setupSubscribers = this.GetDepthSortedComponentsInChildren<IRecycleSetupSubscriber>(greatestDepthFirst: true);
      this._cleanupSubscribers = this.GetDepthSortedComponentsInChildren<IRecycleCleanupSubscriber>(greatestDepthFirst: true);

      this._renderers = this.GetComponentsInChildren<Renderer>();
      this._canvases = this.GetComponentsInChildren<Canvas>();
    }
  }
}