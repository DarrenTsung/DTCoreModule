using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public abstract class FileContextAction : ScriptableObject {
    public abstract void Apply(FileContext fileContext);
  }
}
