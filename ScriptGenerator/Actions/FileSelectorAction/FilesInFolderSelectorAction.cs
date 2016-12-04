using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public class FilesInFolderSelectorAction : FileSelectorAction {
    // PRAGMA MARK - Internal
    [Space(10)]
    [CustomHeader("for file in")]
    [SerializeField, PopulateFromFolder] private string _folderPath;

    protected override IEnumerable<File> SelectFiles() {
      string qualifiedFolderPath = Path.Combine(ApplicationUtil.ProjectPath, this._folderPath);
      if (!Directory.Exists(qualifiedFolderPath)) {
        Debug.LogError("Failed to find directory at: " + qualifiedFolderPath);
        yield break;
      }

      foreach (string fileName in Directory.GetFiles(qualifiedFolderPath)) {
        if (fileName.Contains(".meta")) {
          continue;
        }

        string filePath = Path.Combine(qualifiedFolderPath, fileName);
        string[] lines = System.IO.File.ReadAllLines(filePath);
        yield return new File(filePath, lines);
      }
    }
  }
}
