using DT.ScriptGenerator;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
    [CreateAssetMenu(fileName = "ScriptGenerator", menuName = "ScriptGenerator", order = 1)]
    public class ScriptGenerator : ScriptableObject {
        [SerializeField] private FileSelectorAction _fileSelector;

        public void Run() {
            if (this._fileSelector == null) {
                Debug.LogError("Cannot run ScriptGenerator - no file selector created!");
                return;
            }

            this._fileSelector.Apply();
        }
    }
}
