using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace DT {
  public class OpenableMethodLoader : IOpenableObjectLoader {
    // PRAGMA MARK - Static
    private static IOpenableObject[] methodObjects;
    
    static OpenableMethodLoader() {
      List<IOpenableObject> objects = new List<IOpenableObject>();
      
      // Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
      // foreach (Assembly a in assemblies) {
      Assembly a = Assembly.GetAssembly(typeof(OpenableMethodAttribute));
        foreach (Type t in a.GetTypes()) {
          var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                  .Where(m => m.IsDefined(typeof(OpenableMethodAttribute), false));
          foreach (MethodInfo method in methods) {
            Debug.Log("t.FullName: " + t.FullName);
            Debug.Log("method.Name: " + method.Name);
            OpenableMethod openable = new OpenableMethod(new OpenableMethodConfig {
              methodInfo = method,
              classType = t,
              methodDisplayName = null
            });
            objects.Add(openable);
          }                                                                  
        }
      // }
      
      OpenableMethodLoader.methodObjects = objects.ToArray();
    }
    
    
    // PRAGMA MARK - IOpenableObjectLoader
    public IOpenableObject[] Load() {
      return OpenableMethodLoader.methodObjects;
    }
  }
}