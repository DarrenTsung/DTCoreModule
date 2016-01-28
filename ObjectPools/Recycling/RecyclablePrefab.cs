using UnityEngine;
using UnityEngine.Events;

namespace DT {
  public class RecyclablePrefab : MonoBehaviour {
    public UnityEvent RecycleSetup = new UnityEvent();
    public UnityEvent RecycleCleanup = new UnityEvent();

    public void Setup() {
      this.RecycleSetup.Invoke();
    }

    public void Cleanup() {
      this.RecycleCleanup.Invoke();
    }

    public string prefabName;

    // PRAGMA MARK - Internal
    private void Awake() {
      IRecycleSetupSubscriber[] setupSubscribers = this.GetComponents<IRecycleSetupSubscriber>();
      foreach (IRecycleSetupSubscriber subscriber in setupSubscribers) {
        this.RecycleSetup.AddListener(subscriber.OnRecycleSetup);
      }

      IRecycleCleanupSubscriber[] cleanupSubscribers = this.GetComponents<IRecycleCleanupSubscriber>();
      foreach (IRecycleCleanupSubscriber subscriber in cleanupSubscribers) {
        this.RecycleCleanup.AddListener(subscriber.OnRecycleCleanup);
      }
    }
  }
}