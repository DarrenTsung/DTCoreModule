using System.Collections;
using UnityEditor;
using UnityEngine;

namespace DT {
  [CustomPropertyDrawer(typeof(CustomHeaderAttribute))]
  public class CustomHeaderAttributeDrawer : DecoratorDrawer {
    // PRAGMA MARK - Public Interface
    public override void OnGUI(Rect position) {
      var labelHeader = (CustomHeaderAttribute)this.attribute;

      EditorGUI.LabelField(position, labelHeader.Text, this._LabelStyle);
    }


    // PRAGMA MARK - Internal
    private GUIStyle _labelStyle = null;
    private GUIStyle _LabelStyle {
      get {
        if (this._labelStyle == null) {
          this._labelStyle = new GUIStyle(EditorStyles.boldLabel);
          // add more custom stuff here
        }

        return this._labelStyle;
      }
    }
  }
}