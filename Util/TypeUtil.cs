using DT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DT {
  public static class TypeUtil {
    // PRAGMA MARK - Static Public Interface
    public static FieldInfo[] GetInspectorFields(Type type) {
      if (!TypeUtil._inspectorFieldMapping.ContainsKey(type)) {
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                 .Where((fieldInfo) => {
                                   if (fieldInfo.IsPublic) {
                                     return true;
                                   } else {
                                     return Attribute.IsDefined(fieldInfo, typeof(SerializeField));
                                   }
                                 }).ToArray();
        TypeUtil._inspectorFieldMapping[type] = fields;
      }

      return TypeUtil._inspectorFieldMapping[type];
    }


    // PRAGMA MARK - Static Internal
    private static Dictionary<Type, FieldInfo[]> _inspectorFieldMapping = new Dictionary<Type, FieldInfo[]>();
  }

  public static class TypeUtil<T> {
    // PRAGMA MARK - Static Public Interface
    public static Type[] ImplementationTypes {
      get {
        if (TypeUtil<T>._implementationTypes == null) {
          TypeUtil<T>._implementationTypes =
              (from assembly in AppDomain.CurrentDomain.GetAssemblies()
               from type in assembly.GetTypes()
               where typeof(T).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract
               select type).ToArray();
        }
        return TypeUtil<T>._implementationTypes;
      }
    }


    // PRAGMA MARK - Static Internal
    private static Type[] _implementationTypes = null;
  }
}
