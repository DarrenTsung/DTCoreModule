using System;
using System.Collections;
using UnityEngine;

namespace DT {
  public class DTStateMachineBehaviour : StateMachineBehaviour {
    // PRAGMA MARK - StateMachineBehaviour Lifecycle
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      this.OnStateEntered();
      this._active = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      this._active = false;
      this.OnStateExited();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      this.OnStateUpdated();
    }


    // PRAGMA MARK - Internal
    private bool _active = false;

    void OnDisable() {
      if (this._active) {
        this.OnStateExited();
      }
    }

    protected virtual void OnStateEntered() {}
    protected virtual void OnStateExited() {}
    protected virtual void OnStateUpdated() {}
  }
}