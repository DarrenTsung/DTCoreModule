using System;
using UnityEngine;

namespace DT {
  public interface IStateBehaviour<TStateMachine> {
    void InitializeWithContext(Animator animator, TStateMachine stateMachine);
  }

  public interface IStateBehaviour<TStateMachine, U> {
    void InitializeWithContext(Animator animator, TStateMachine stateMachine, U context);
  }
}