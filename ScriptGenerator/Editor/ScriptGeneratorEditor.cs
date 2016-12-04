using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  [CustomEditor(typeof(ScriptGenerator))]
  [CanEditMultipleObjects]
  public class ScriptGeneratorEditor : Editor {
    public override void OnInspectorGUI() {
      this.DrawDefaultInspector();

      if (GUILayout.Button("Run")) {
        (this.target as ScriptGenerator).Run();
      }
    }
  }
}
