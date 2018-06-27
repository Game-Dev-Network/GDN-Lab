using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ReadOnlyTextAreaAttribute))]
public class ReadOnlyTextAreaDrawer : PropertyDrawer {

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        ReadOnlyTextAreaAttribute readOnlyAreaAttribute = (ReadOnlyTextAreaAttribute)attribute;
        return readOnlyAreaAttribute.textLines * 16f;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        GUI.enabled = false;

        EditorGUI.BeginProperty(position, label, property);

        EditorStyles.textField.wordWrap = true;
        var rect = new Rect(position.x, position.y, position.width, position.height);
        EditorGUI.TextArea(rect, property.stringValue);

        EditorGUI.EndProperty();

        GUI.enabled = true;
    }
}