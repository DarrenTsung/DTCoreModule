using DT;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public class RegexReplacementPopulator : ReplacementPopulator {
    // PRAGMA MARK - Public Interface
    public override void Populate(FileContext fileContext) {
      Regex regex = new Regex(this._serializedRegex);

      foreach (string line in fileContext.File.Lines) {
        Match m = regex.Match(line);
        while (m.Success) {
          string[] matchGroups = m.Groups.ESelect(o => (o as Group).Value).ToArray();
          string replacementKey = string.Format(this._replacementKeyFormat, matchGroups);
          string replacementValue = string.Format(this._replacementValueFormat, matchGroups);

          fileContext.SetReplacement(replacementKey, replacementValue);

          m = m.NextMatch();
        }
      }
    }


    // PRAGMA MARK - Internal
    [CustomHeader("let")]
    [SerializeField] private string _replacementKeyFormat = "{0}";
    [CustomHeader("map to")]
    [SerializeField] private string _replacementValueFormat = "{0}";

    [CustomHeader("parsed from")]
    [SerializeField] private string _serializedRegex = @"private void ExampleFunc(\w+)\(";
  }
}
