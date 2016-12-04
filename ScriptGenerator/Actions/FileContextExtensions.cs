using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public static class FileContextExtensions {
    public static string FormatString(this FileContext fileContext, string s) {
      MatchEvaluator evaluator = new MatchEvaluator((Match m) => {
        string variableKey = m.Groups[1].Value;
        if (!fileContext.HasReplacementFor(variableKey)) {
          Debug.LogWarning("Failed to replace key: " + variableKey);
          return m.Value;
        }

        return fileContext.GetReplacementFor(variableKey);
      });
      return Regex.Replace(s, @"\${([^}]+)}", evaluator);
    }
  }
}
