using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlexibleUI), true), CanEditMultipleObjects,]
public class FlexibleUIInspector : Editor {
    private FlexibleUI flexibleUI;

    private void OnEnable() {
        flexibleUI = (FlexibleUI)target;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Add Layout Element")) {
            flexibleUI.AddLayoutElement();
        }
    }
}