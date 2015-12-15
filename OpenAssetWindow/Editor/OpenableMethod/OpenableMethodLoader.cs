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
      
      List<Assembly> assemblies = new List<Assembly>();
      // Editor Assembly
      assemblies.Add(Assembly.GetAssembly(typeof(OpenableMethodLoader)));
      // Runtime Assembly
      assemblies.Add(Assembly.GetAssembly(typeof(OpenableMethodAttribute)));
      
      foreach (Assembly a in assemblies) {
        foreach (Type t in a.GetTypes()) {
          bool hasOpenableClassAttribute = false;
          System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t); 
          foreach (System.Attribute attr in attrs) {
            if (attr is OpenableClassAttribute) {
              hasOpenableClassAttribute = true;
            }
          }
          
          if (!hasOpenableClassAttribute) {
            continue;
          }
          
          var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
          foreach (MethodInfo method in methods) {
            OpenableMethodAttribute attr = method.GetCustomAttributes(true).OfType<OpenableMethodAttribute>().FirstOrDefault();
            if (attr == null) {
              continue;
            }
            
            OpenableMethod openable = new OpenableMethod(new OpenableMethodConfig {
              methodInfo = method,
              classType = t,
              methodDisplayName = attr.methodDisplayName
            });
            objects.Add(openable);
          }                                                                  
        }
      }
      
      OpenableMethodLoader.methodObjects = objects.ToArray();
    }
    
    
    // PRAGMA MARK - IOpenableObjectLoader
    public IOpenableObject[] Load() {
      return OpenableMethodLoader.methodObjects;
    }
  }
}