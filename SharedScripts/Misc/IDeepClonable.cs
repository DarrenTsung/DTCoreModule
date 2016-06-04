using System.Collections;

namespace DT {
  public interface IDeepClonable<T> {
    T DeepClone();
  }
}
