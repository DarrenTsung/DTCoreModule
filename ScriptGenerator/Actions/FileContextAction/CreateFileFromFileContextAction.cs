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

      string formattedTemplate = fileContext.FormatString(this._template.text);
      if (System.IO.File.Exists(fullFilePath)) {
        using (StreamReader sr = System.IO.File.OpenText(fullFilePath)) {
          string fileContents = sr.ReadToEnd();
          // if file is the same as template
          if (fileContents == formattedTemplate) {
            if (ScriptGenerator.Log) Debug.Log(string.Format("Skipped generating script at: {0} because file written is up-to-date.", fullFilePath));
            return;
          }
        }
      }

      using (FileStream fs = System.IO.File.Create(fullFilePath)) {
        byte[] text = new UTF8Encoding(true).GetBytes(formattedTemplate);
        fs.Write(text, 0, text.Length);
      }

      if (ScriptGenerator.Log) Debug.Log(string.Format("Generated script at: {0}.", fullFilePath));
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
