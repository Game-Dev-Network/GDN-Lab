using UnityEngine;

/// <summary>
/// Usage [ReadOnlyTextAreaDrawer(numberOfLinesToDisplay = 1)] attribute for the inspector
/// </summary>
public class ReadOnlyTextAreaAttribute : PropertyAttribute {
    public int textLines;

    public ReadOnlyTextAreaAttribute(int textLines) {
        this.textLines = textLines;
    }

    public ReadOnlyTextAreaAttribute() {
        textLines = 1;
    }

}