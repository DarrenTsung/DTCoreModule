using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
    public class CreateFileFromFileContextAction : FileContextAction {
        // PRAGMA MARK - Public Interface
        public override void Apply(FileContext fileContext) {
            Debug.Log("Creating fileContext: " + fileContext);
        }


        // PRAGMA MARK - Internal
        // TODO (darren): open folder selector to fill out this string? custom property drawer
        [SerializeField] private string _filePath;
        [SerializeField] private TextAsset _template;
    }
}
