using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT {
  public static class AnimatorExtensions {
    public static bool IsCurrentStateNamed(this Animator animator, int layerIndex, params string[] names) {
      AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

      foreach (string name in names) {
        if (currentStateInfo.IsName(name)) {
          return true;
        }
      }

      return false;
    }

    public static bool IsCurrentState(this Animator animator, int layerIndex, params int[] fullPathHashes) {
      AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

      foreach (int fullPathHash in fullPathHashes) {
        if (currentStateInfo.fullPathHash == fullPathHash) {
          return true;
        }
      }

      return false;
    }

    public static T GetRequiredBehaviour<T>(this Animator animator) where T : StateMachineBehaviour {
      T behaviour = animator.GetBehaviour<T>();
      if (behaviour == null) {
        Debug.LogError("GetRequiredBehaviour: Behaviour " + typeof(T).Name + " missing in " + animator.gameObject.FullName());
      }
      return behaviour;
    }

    public static Animator SetTimeForCurrentClip(this Animator animator, float normalizedTime, int layer = 0) {
      AnimatorClipInfo[] currentClipInfo = animator.GetCurrentAnimatorClipInfo(layer);
      if (currentClipInfo.Length > 0) {
        AnimationClip clip = currentClipInfo[0].clip;
        animator.Play(clip.name, layer, normalizedTime);
      }

      return animator;
    }
  }
}