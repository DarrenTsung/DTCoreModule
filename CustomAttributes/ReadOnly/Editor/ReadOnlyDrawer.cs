using UnityEditor;
using UnityEngine;

namespace DT {
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	public class ReadOnlyDrawer : PropertyDrawer {
		public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label) {
			string valueStr;
			switch (_property.propertyType) {
				case SerializedPropertyType.Integer:
					valueStr = _property.intValue.ToString();
					break;
				case SerializedPropertyType.Boolean:
					valueStr = _property.boolValue.ToString();
					break;
				case SerializedPropertyType.Float:
					valueStr = _property.floatValue.ToString("0.00000");
					break;
				case SerializedPropertyType.String:
					valueStr = _property.stringValue;
					break;
				case SerializedPropertyType.Enum:
					valueStr = _property.enumDisplayNames[_property.enumValueIndex];
					break;
				case SerializedPropertyType.Vector2:
					valueStr = _property.vector2Value.ToString();
					break;
				case SerializedPropertyType.Vector3:
					valueStr = _property.vector3Value.ToString();
					break;
				default:
					valueStr = "(not supported)";
					break;
			}

			EditorGUI.LabelField(_position, _label.text + ":", valueStr);
		}
	}
}