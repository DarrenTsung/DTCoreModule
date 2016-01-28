using System.Collections;

namespace DT {
  public interface IRecycleSetupSubscriber {
    void OnRecycleSetup();
  }

  public interface IRecycleCleanupSubscriber {
    void OnRecycleCleanup();
  }
}