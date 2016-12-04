using System.Collections;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace DT {
  [CustomPropertyDrawer(typeof(PopulateFromFolderAttribute))]
  public class PopulateFromFolderAttributeDrawer : PropertyDrawer {
    // PRAGMA MARK - Public Interface
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label) {
      if (property.propertyType != SerializedPropertyType.String) {
        EditorGUI.LabelField(rect, "PopulateFromFolder must be used on string property!");
        return;
      }

      Rect folderSelectRect = new Rect(rect.position.AddX(rect.width - _kWidth), rect.size.SetX(_kWidth));
      Rect propertyRect = new Rect(rect.position, rect.size.SubtractX(_kWidth + _kPadding));

      if (GUI.Button(folderSelectRect, "..")) {
        string startingFolder = string.IsNullOrEmpty(property.stringValue) ? ApplicationUtil.ProjectPath : property.stringValue;

        string folderPath = EditorUtility.OpenFolderPanel("Choose Folder Path", folder: startingFolder, defaultName: "");
        if (!string.IsNullOrEmpty(folderPath)) {
          if (!folderPath.IsSubPathOf(ApplicationUtil.ProjectPath)) {
            Debug.LogError("Cannot use path that is outside of the project directory!");
          } else {
            property.stringValue = folderPath.Replace(ApplicationUtil.ProjectPath, "");
            property.serializedObject.ApplyModifiedProperties();
          }
        }
      }

      // remove / from the beginning if necessary
      Regex r = new Regex(@"^/+");
      if (r.IsMatch(property.stringValue)) {
        string trimmedString = r.Replace(property.stringValue, "");
        property.stringValue = trimmedString;
        property.serializedObject.ApplyModifiedProperties();
      }

      EditorGUI.PropertyField(propertyRect, property, label);
    }


    // PRAGMA MARK - Internal
    private const float _kWidth = 25.0f;
    private const float _kPadding = 5.0f;
  }
}