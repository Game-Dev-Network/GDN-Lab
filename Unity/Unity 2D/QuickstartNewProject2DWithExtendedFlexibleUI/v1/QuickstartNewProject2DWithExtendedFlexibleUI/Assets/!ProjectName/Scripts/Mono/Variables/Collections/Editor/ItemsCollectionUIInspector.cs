using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemsCollectionUI)), CanEditMultipleObjects]
public class ItemsCollectionUIInspector : Editor {
    private SerializedProperty itemsCollectionUI;
    private SerializedProperty scriptName;

    private void OnEnable() {
        itemsCollectionUI = serializedObject.FindProperty("Items");
        scriptName = serializedObject.FindProperty("m_Script");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(scriptName, true, new GUILayoutOption[0]);
        EditorGUI.EndDisabledGroup();
        EditorList.Show(itemsCollectionUI, true);
        serializedObject.ApplyModifiedProperties();
    }
}