using System;

namespace DT {
  public interface IOpenableWithArgumentsObject : IOpenableObject {
    void Open(object[] args = null);
  }
}