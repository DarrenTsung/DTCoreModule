using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
    public class FilesInFolderSelectorAction : FileSelectorAction {
        // PRAGMA MARK - Internal
        [SerializeField] private string _folderPath;

        protected override IEnumerable<File> SelectFiles() {
            if (!Directory.Exists(this._folderPath)) {
                Debug.LogError("Failed to find directory at: " + this._folderPath);
                yield break;
            }

            foreach (string fileName in Directory.GetFiles(this._folderPath)) {
                string filePath = Path.Combine(this._folderPath, fileName);
                string[] lines = System.IO.File.ReadAllLines(filePath);
                yield return new File(filePath, lines);
            }
        }
    }
}
