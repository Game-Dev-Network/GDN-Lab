using TMPro;
using UnityEditor;
using UnityEngine;

public abstract class FlexibleUIInstance : Editor {

    [MenuItem("GameObject/Flexible UI/Button", priority = 0)]
    public static void AddButton() {
        GameObject buttonGO = Create<FlexibleUIButton>("Button");
        GameObject textGO = Create<FlexibleUIText>("Text", buttonGO);
        TextMeshProUGUI text = textGO.GetComponent<TextMeshProUGUI>();
        text.text = "Button";
        text.alignment = TextAlignmentOptions.Center;
        text.font = PopRef.Instance.themeSwap.allFlexibleUIData[PopRef.Instance.themeSwap.activeIndex].fontAsset;
    }

    [MenuItem("GameObject/Flexible UI/Panel", priority = 0)]
    public static void AddPanel() {
        Create<FlexibleUIPanel>("Panel");
    }

    [MenuItem("GameObject/Flexible UI/Text", priority = 0)]
    public static void AddText() {
        GameObject textGO = Create<FlexibleUIText>("Text");
        TextMeshProUGUI text = textGO.GetComponent<TextMeshProUGUI>();
        text.text = "Text";
        text.alignment = TextAlignmentOptions.Center;
        text.font = PopRef.Instance.themeSwap.allFlexibleUIData[PopRef.Instance.themeSwap.activeIndex].fontAsset;
    }

    private static GameObject Create<T>(string objectName, GameObject go = null) where T : Object {
        GameObject instance = new GameObject(objectName, typeof(T));
        if (go == null) {
            GameObject clickedObject = Selection.activeGameObject;
            if (clickedObject != null) {
                instance.transform.SetParent(clickedObject.transform, false);
            }
        }
        else instance.transform.SetParent(go.transform, false);
        return instance;
    }
}