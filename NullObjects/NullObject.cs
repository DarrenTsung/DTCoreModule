using System.Collections;

namespace DT {
  public class NullObject<TSubclassNullObject> where TSubclassNullObject : new() {
    public static TSubclassNullObject Instance {
      get { return SingletonUtil<TSubclassNullObject>.Instance; }
    }
  }
}