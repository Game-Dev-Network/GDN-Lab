using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Custom/UI/FlexibleUIData")]
public class FlexibleUIData : ScriptableObject {
    public ItemsCollectionUI allUIObjects;
    public Sprite buttonSprite;
    public Color color;
    public TMP_FontAsset fontAsset;
    public Material fontMaterial;
    public float fontSize;
    public float elementWidth;
    public float elementHeight;

    private void OnValidate() {
        //Upon switching item list, move everything to new one
        int count = allUIObjects.Items.Count - 1;
        for (int i = count; i >= 0; i--) {
            //take out leftover empty items
            if (allUIObjects.Items[i] == null) {
                allUIObjects.Remove(allUIObjects.Items[i]);
                continue;
            }
            CollectionItemUI collectionItemUI = ((CollectionItemUI)allUIObjects.Items[i]);
            FlexibleUI flexibleUI = collectionItemUI.GetComponent<FlexibleUI>();
            LayoutElement layoutElement = collectionItemUI.GetComponent<LayoutElement>();
            if (layoutElement != null) {
                layoutElement.minWidth = layoutElement.preferredWidth = elementWidth;
                layoutElement.minHeight = layoutElement.preferredHeight = elementHeight;
            }
            flexibleUI.OnSkinUI();
        }
    }
}