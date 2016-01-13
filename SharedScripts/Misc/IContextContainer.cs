using System;

namespace DT {
  public interface IContextContainer {
    void ProvideContext(object context);
  }
  
  public interface IContextContainer<T> : IContextContainer {
    void ProvideContext(T context);
  }
}