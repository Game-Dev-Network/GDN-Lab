using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CollectionItemUI))]
public class FlexibleUIButton : FlexibleUI {
    private Button button;
    private Image image;

    public override void OnSkinUI() {
        base.OnSkinUI();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.targetGraphic = image;
        image.type = Image.Type.Sliced;
        image.sprite = flexibleUIData.buttonSprite;
        image.color = flexibleUIData.color;
    }
}