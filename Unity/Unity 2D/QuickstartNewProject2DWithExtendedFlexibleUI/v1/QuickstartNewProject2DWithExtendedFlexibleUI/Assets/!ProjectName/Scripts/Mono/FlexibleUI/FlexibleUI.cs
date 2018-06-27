using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public abstract class FlexibleUI : MonoBehaviour {
    public FlexibleUIData flexibleUIData;
    public static PopRef popRef;

    private void OnEnable() {
        if (popRef == null) popRef = FindObjectOfType<PopRef>();
        if (flexibleUIData == null) flexibleUIData = popRef.themeSwap.allFlexibleUIData[popRef.themeSwap.activeIndex];
        OnSkinUI();
    }

    public virtual void OnSkinUI() {
        LayoutElement layoutElement = GetComponent<LayoutElement>();
        if (layoutElement != null) {
            UpdateLayout(layoutElement, flexibleUIData.elementWidth, flexibleUIData.elementHeight);
        }
    }

    private void OnValidate() {
        OnSkinUI();
    }

    public void AddLayoutElement() {
        if (GetComponent<LayoutElement>() || GetComponent<LayoutGroup>()) return;
        LayoutElement layoutElement = gameObject.AddComponent<LayoutElement>();
        UpdateLayout(layoutElement, flexibleUIData.elementWidth, flexibleUIData.elementHeight);
    }

    private void UpdateLayout(LayoutElement layoutElement, float width, float height) {
        layoutElement.preferredWidth = layoutElement.minWidth = width;
        layoutElement.preferredHeight = layoutElement.minHeight = height;
    }
}