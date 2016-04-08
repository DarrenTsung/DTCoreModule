using System;
using System.Linq;
using System.Reflection;

namespace DT {
  public class InspectorMethodButtonData {
    public MethodInfo method;

    public ParameterInfo[] parameters;
    public object[] parameterArguments;

    public InspectorMethodButtonData(MethodInfo method) {
      this.method = method;

      this.parameters = this.method.GetParameters();
      this.parameterArguments = new object[this.parameters.Length];
      for (int i = 0; i < this.parameters.Length; i++) {
        ParameterInfo parameter = this.parameters[i];
        parameterArguments[i] = parameter.ParameterType.IsValueType ? System.Activator.CreateInstance(parameter.ParameterType) : null;
      }
    }
  }
}