using DT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
﻿using UnityEngine;

namespace DT {
	public static class GameObjectValidator {
		public class ValidationError {
      public Component component;
      public Type componentType;
      public FieldInfo fieldInfo;

      public ValidationError(Component component, Type componentType, FieldInfo fieldInfo) {
        this.component = component;
        this.componentType = componentType;
        this.fieldInfo = fieldInfo;
      }

      public override string ToString() {
        return string.Format("{0}->{1}->{2}", this.component.gameObject.FullName(), this.componentType.Name, this.fieldInfo.Name);
      }
		}

    public static HashSet<Assembly> kUnityAssemblies = new HashSet<Assembly>() {
      Assembly.GetAssembly(typeof(UnityEngine.MonoBehaviour)),
      Assembly.GetAssembly(typeof(UnityEngine.UI.Text)),
      Assembly.GetAssembly(typeof(UnityEditor.Editor))
    };

    public static IList<ValidationError> Validate(GameObject gameObject) {
      List<ValidationError> validationErrors = null;

      Queue<GameObject> queue = new Queue<GameObject>();
      queue.Enqueue(gameObject);

      while (queue.Count > 0) {
        GameObject current = queue.Dequeue();

        Component[] components = current.GetComponents<Component>();
        if (components == null) {
          continue;
        }

        foreach (Component c in components) {
          if (c == null) {
            continue;
          }

          Type componentType = c.GetType();
          if (kUnityAssemblies.Contains(componentType.Assembly)) {
            continue;
          }

          foreach (FieldInfo fieldInfo in TypeUtil.GetInspectorFields(componentType)
                                                  .Where(f => !Attribute.IsDefined(f, typeof(OptionalAttribute)) && !Attribute.IsDefined(f, typeof(HideInInspector)))) {
            // NOTE (darren): this is to ignore fields that declared in super-classes out of our control (Unity)
            if (kUnityAssemblies.Contains(fieldInfo.DeclaringType.Assembly)) {
              continue;
            }

            bool isInvalid = false;
            if (fieldInfo.FieldType.IsClass && typeof(UnityEngine.Object).IsAssignableFrom(fieldInfo.FieldType)) {
              isInvalid = (UnityEngine.Object)fieldInfo.GetValue(c) == null;
            } else if (typeof(IEnumerable).IsAssignableFrom(fieldInfo.FieldType)) {
              var enumerable = (IEnumerable)fieldInfo.GetValue(c);
              if (!(enumerable.EFirstOrDefault() is UnityEngine.Object)) {
                continue;
              }

              isInvalid = enumerable.EAny(o => (UnityEngine.Object)o == null);
            } else {
              // not anything we can validate
              continue;
            }

            if (isInvalid) {
              validationErrors = validationErrors ?? new List<ValidationError>();
              validationErrors.Add(new ValidationError(c, componentType, fieldInfo));
            }
          }
        }

        foreach (GameObject child in current.GetChildren()) {
          queue.Enqueue(child);
        }
      }

      return validationErrors;
    }
	}
}
