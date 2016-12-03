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
            foreach (string line in fileContext.File.Lines) {
                Match m = this._regex.Match(line);
                while (m.Success) {
                    string replacementKey = string.Format(this._replacementKeyFormat, m.Groups);
                    string replacementValue = string.Format(this._replacementValueFormat, m.Groups);

                    fileContext.SetReplacement(replacementKey, replacementValue);

                    m = m.NextMatch();
                }
            }
        }


        // PRAGMA MARK - Internal
        [Header("let")]
        [SerializeField] private string _replacementKeyFormat = "{0}";
        [Header("map to")]
        [SerializeField] private string _replacementValueFormat = "{0}";

        [Header("parsed from")]
        [SerializeField] private Regex _regex;
    }
}
