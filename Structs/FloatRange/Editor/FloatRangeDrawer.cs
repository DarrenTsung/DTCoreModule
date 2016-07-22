using UnityEditor;
using UnityEngine;

namespace DT {
  [CustomPropertyDrawer(typeof(FloatRange))]
  public class FloatRangeDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      label = EditorGUI.BeginProperty(position, label, property);
      position = EditorGUI.PrefixLabel(position, label);

      SerializedProperty minProp = property.FindPropertyRelative("min");
      SerializedProperty maxProp = property.FindPropertyRelative("max");

      float min = minProp.floatValue;
      float max = maxProp.floatValue;

      float rangeMin = 0;
      float rangeMax = 1;

      var ranges = (MinMaxRangeAttribute[])fieldInfo.GetCustomAttributes(typeof(MinMaxRangeAttribute), true);
      if (ranges.Length > 0) {
        rangeMin = ranges[0].Min;
        rangeMax = ranges[0].Max;
      }

      const float kRangeBoundsLabelWidth = 40f;

      var rangeBoundsLabel1Rect = new Rect(position);
      rangeBoundsLabel1Rect.width = kRangeBoundsLabelWidth;
      GUI.Label(rangeBoundsLabel1Rect, new GUIContent(min.ToString("F2")));
      position.xMin += kRangeBoundsLabelWidth;

      var rangeBoundsLabel2Rect = new Rect(position);
      rangeBoundsLabel2Rect.xMin = rangeBoundsLabel2Rect.xMax - kRangeBoundsLabelWidth;
      GUI.Label(rangeBoundsLabel2Rect, new GUIContent(max.ToString("F2")));
      position.xMax -= kRangeBoundsLabelWidth;

      EditorGUI.BeginChangeCheck();
      EditorGUI.MinMaxSlider(position, ref min, ref max, rangeMin, rangeMax);
      if (EditorGUI.EndChangeCheck()) {
        minProp.floatValue = min;
        maxProp.floatValue = max;
      }

      EditorGUI.EndProperty();
    }
  }
}