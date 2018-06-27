using UnityEngine;

[ExecuteInEditMode]
public class CollectionItemUI : MonoBehaviour {
    public ItemsCollectionUI allUIObjects;
    public static PopRef popRef;

    private void OnEnable() {
        if (popRef == null) popRef = FindObjectOfType<PopRef>();
        if (allUIObjects == null) allUIObjects = popRef.themeSwap.allFlexibleUIData[popRef.themeSwap.activeIndex].allUIObjects;
        allUIObjects.Add(this);
    }

    private void OnDisable() {
        allUIObjects.Remove(this);
    }
}