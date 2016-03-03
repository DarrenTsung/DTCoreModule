using System;
using UnityEngine;

namespace DT {
  public static class StateBehaviourExtensions {
    public static void ConfigureAllStateBehaviours<T>(this T obj, Animator animator) {
      StateMachineBehaviour[] behaviours = animator.GetBehaviours<StateMachineBehaviour>();
      foreach (StateMachineBehaviour behaviour in behaviours) {
        IStateBehaviour<T> configurableState = behaviour as IStateBehaviour<T>;

        if (configurableState == null) {
          continue;
        }

        configurableState.InitializeWithContext(obj, animator);
      }
    }
  }
}