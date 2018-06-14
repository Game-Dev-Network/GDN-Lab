using UnityEditor;
using UnityEngine;

public static class EditorList {

    public static void Show(SerializedProperty list, bool showListSize = true, bool allowSceneObjects = false) {
        EditorGUILayout.PropertyField(list);
        EditorGUI.indentLevel += 1;
        if (showListSize) {
            EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        }
        if (list.isExpanded) {
            if (!showListSize) {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
            }
            int count = list.arraySize;
            for (int i = 0; i < count; i++) {
                EditorGUILayout.ObjectField(list.GetArrayElementAtIndex(i).objectReferenceValue, typeof(Object), true);
            }
        }
        EditorGUI.indentLevel -= 1;
    }
}