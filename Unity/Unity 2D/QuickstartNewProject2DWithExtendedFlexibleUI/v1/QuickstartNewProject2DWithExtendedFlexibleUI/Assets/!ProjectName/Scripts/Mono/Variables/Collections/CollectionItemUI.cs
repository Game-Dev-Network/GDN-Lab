using UnityEngine;

[ExecuteInEditMode]
public class CollectionItemUI : MonoBehaviour {
    public ItemsCollectionUI allUIObjects;

    private void OnEnable() {
        if (allUIObjects == null) allUIObjects = PopRef.Instance.themeSwap.allFlexibleUIData[PopRef.Instance.themeSwap.activeIndex].allUIObjects;
        allUIObjects.Add(this);
    }

    private void OnDisable() {
        allUIObjects.Remove(this);
    }
}