using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public abstract class ReplacementPopulator : EmbeddedScriptableObject {
    public abstract void Populate(FileContext fileContext);
  }
}
