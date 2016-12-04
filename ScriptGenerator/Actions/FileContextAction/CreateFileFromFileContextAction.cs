using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace DT.ScriptGenerator {
  public class CreateFileFromFileContextAction : FileContextAction {
    // PRAGMA MARK - Public Interface
    public override void Apply(FileContext fileContext) {
      if (this._template == null) {
        Debug.LogError("No template - cannot create File!");
        return;
      }

      string qualifiedFolderPath = Path.Combine(ApplicationUtil.ProjectPath, this._folderPath);
      if (!Directory.Exists(qualifiedFolderPath)) {
        Debug.LogError("Cannot open folder path at: " + qualifiedFolderPath);
        return;
      }

      string formattedFileName = fileContext.FormatString(this._fileName);
      if (formattedFileName.Contains('$')) {
        Debug.LogWarning("Failed to populate all variables in fileName: " + formattedFileName);
        return;
      }

      string fullFilePath = Path.Combine(qualifiedFolderPath, formattedFileName);
      using (FileStream fs = System.IO.File.Create(fullFilePath)) {
        byte[] text = new UTF8Encoding(true).GetBytes(fileContext.FormatString(this._template.text));
        fs.Write(text, 0, text.Length);
      }

      AssetDatabase.ImportAsset(Path.Combine(this._folderPath, formattedFileName));
    }


    // PRAGMA MARK - Internal
    [CustomHeader("create file named")]
    [SerializeField] private string _fileName = "Example${var}";
    [CustomHeader("from template")]
    [SerializeField] private TextAsset _template;
    [CustomHeader("in folder")]
    [SerializeField, PopulateFromFolder] private string _folderPath;
  }
}
