using DT;
using System;
using System.Collections;
using System.Linq;

namespace DT {
  public static class TypeUtil<T> {
    // PRAGMA MARK - Static Public Interface
    public static Type[] ImplementationTypes {
      get { return TypeUtil<T>._implementationTypes; }
    }


    // PRAGMA MARK - Static Internal
    private static Type[] _implementationTypes;

    static TypeUtil() {
      TypeUtil<T>._implementationTypes =
          (from assembly in AppDomain.CurrentDomain.GetAssemblies()
           from type in assembly.GetTypes()
           where typeof(T).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract
           select type).ToArray();
    }
  }
}
