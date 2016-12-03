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
        List<FieldInfo> fieldInfos = new List<FieldInfo>();
        Type iterType = type;
        while (iterType != null) {
          fieldInfos.AddRange(iterType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                  .Where(f => f.IsPublic || Attribute.IsDefined(f, typeof(SerializeField))));
          iterType = iterType.BaseType;
        }

        TypeUtil._inspectorFieldMapping[type] = fieldInfos.ToArray();
      }

      return TypeUtil._inspectorFieldMapping[type];
    }

    public static Type[] GetImplementationTypes(Type inputType) {
      if (!TypeUtil._implementationTypeMapping.ContainsKey(inputType)) {
        TypeUtil._implementationTypeMapping[inputType] = TypeUtil.AllAssemblyTypes
                                                                 .Where(t => inputType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsGenericType)
                                                                 .ToArray();
      }

      return TypeUtil._implementationTypeMapping[inputType];
    }

    public static string[] GetImplementationTypeNames(Type type) {
      if (!TypeUtil._implementationTypeNameMapping.ContainsKey(type)) {
        TypeUtil._implementationTypeNameMapping[type] = TypeUtil.GetImplementationTypes(type).Select(t => t.Name).ToArray();
      }

      return TypeUtil._implementationTypeNameMapping[type];
    }

    public static Type[] AllAssemblyTypes {
      get {
        return TypeUtil._allAssemblyTypes ?? (TypeUtil._allAssemblyTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
           from type in assembly.GetTypes()
           select type).ToArray());
      }
    }


    // PRAGMA MARK - Static Internal
    private static Dictionary<Type, FieldInfo[]> _inspectorFieldMapping = new Dictionary<Type, FieldInfo[]>();
    private static Dictionary<Type, Type[]> _implementationTypeMapping = new Dictionary<Type, Type[]>();
    private static Dictionary<Type, string[]> _implementationTypeNameMapping = new Dictionary<Type, string[]>();

    private static Type[] _allAssemblyTypes = null;
  }
}
