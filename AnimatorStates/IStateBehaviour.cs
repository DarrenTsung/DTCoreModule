using System;
using UnityEngine;

namespace DT {
  public interface IStateBehaviour<T> {
    void InitializeWithContext(T context, Animator animator);
  }
}