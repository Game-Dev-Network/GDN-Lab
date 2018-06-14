using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CollectionItemUI))]
public class FlexibleUIPanel : FlexibleUI {
    private Image image;

    public override void OnSkinUI() {
        base.OnSkinUI();
        image = GetComponent<Image>();
        image.type = Image.Type.Sliced;

        image.sprite = flexibleUIData.buttonSprite;
        image.color = flexibleUIData.color;
    }
}