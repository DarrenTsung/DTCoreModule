using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public class FileContext {
    public File File { get; private set; }

    public bool HasReplacementFor(string key) {
      return this._replacements.ContainsKey(key.ToLower());
    }

    public string GetReplacementFor(string key) {
      return this._replacements.GetRequiredValueOrDefault(key.ToLower());
    }

    public void SetReplacement(string key, string value) {
      this._replacements.SetAndWarnIfReplacing(key.ToLower(), value);
    }

    private Dictionary<string, string> _replacements = new Dictionary<string, string>();

    public FileContext(File file) {
      this.File = file;
    }
  }
}
