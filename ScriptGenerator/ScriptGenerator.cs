using DT.ScriptGenerator;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  [CreateAssetMenu(fileName = "ScriptGenerator", menuName = "ScriptGenerator", order = 1)]
  public class ScriptGenerator : ScriptableObject {
    public static bool Log {
      get { return EditorPrefs.GetBool("ScriptGenerator::Log"); }
      set { EditorPrefs.SetBool("ScriptGenerator::Log", value); }
    }

    [SerializeField] private FileSelectorAction _fileSelector;

    public void Run() {
      if (this._fileSelector == null) {
        Debug.LogError("Cannot run ScriptGenerator - no file selector created!");
        return;
      }

      if (ScriptGenerator.Log) Debug.Log(string.Format("Running script generator - {0}..", this.name));

      this._fileSelector.Apply();
    }
  }
}
