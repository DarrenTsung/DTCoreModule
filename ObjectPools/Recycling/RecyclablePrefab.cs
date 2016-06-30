using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT {
  public class RecyclablePrefab : MonoBehaviour {
    public Action<RecyclablePrefab> OnCleanup = delegate {};

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
      this.OnCleanup.Invoke(this);

      foreach (Renderer renderer in this._renderers) {
        renderer.enabled = false;
      }

      foreach (Canvas canvas in this._canvases) {
        canvas.enabled = false;
      }

      foreach (IRecycleCleanupSubscriber subscriber in this._cleanupSubscribers) {
        subscriber.OnRecycleCleanup();
      }

      foreach (RecyclablePrefab r in this._attachedChildRecycables) {
        r.OnCleanup -= this.DetachChildRecyclableObject;
        ObjectPoolManager.Recycle(r.gameObject);
      }
      this._attachedChildRecycables.Clear();
    }

    public void AttachChildRecyclableObject(GameObject child) {
      RecyclablePrefab r = child.GetRequiredComponent<RecyclablePrefab>();
      bool addedSuccessfully = this._attachedChildRecycables.Add(r);
      if (!addedSuccessfully) {
        Debug.LogWarning("AttachChildRecyclableObject - child recyclablePrefab already in attachedCleanupSubscribers!");
        return;
      }

      r.OnCleanup += this.DetachChildRecyclableObject;
    }

    public string prefabName;

    // PRAGMA MARK - Internal
    private IRecycleSetupSubscriber[] _setupSubscribers;
    private IRecycleCleanupSubscriber[] _cleanupSubscribers;

    private HashSet<RecyclablePrefab> _attachedChildRecycables = new HashSet<RecyclablePrefab>();

    private Renderer[] _renderers;
    private Canvas[] _canvases;

    private void Awake() {
      this._setupSubscribers = this.GetDepthSortedComponentsInChildren<IRecycleSetupSubscriber>(greatestDepthFirst: true);
      this._cleanupSubscribers = this.GetDepthSortedComponentsInChildren<IRecycleCleanupSubscriber>(greatestDepthFirst: true);

      this._renderers = this.GetComponentsInChildren<Renderer>();
      this._canvases = this.GetComponentsInChildren<Canvas>();
    }

    private void DetachChildRecyclableObject(RecyclablePrefab r) {
      r.OnCleanup -= this.DetachChildRecyclableObject;
      bool successful = this._attachedChildRecycables.Remove(r);
      if (!successful) {
        Debug.LogWarning("DetachChildRecyclableObject - failed to find child recyclablePrefab in attachedCleanupSubscribers!");
      }
    }
  }
}