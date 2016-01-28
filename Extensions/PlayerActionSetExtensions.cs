using DT;

#if IN_CONTROL
using InControl;

namespace DT {
  public static class PlayerActionSetExtensions {
    public static bool HasAttachedDevice(this PlayerActionSet actionSet) {
      return actionSet.Device != null && actionSet.Device.IsAttached;
    }
  }
}
#endif
