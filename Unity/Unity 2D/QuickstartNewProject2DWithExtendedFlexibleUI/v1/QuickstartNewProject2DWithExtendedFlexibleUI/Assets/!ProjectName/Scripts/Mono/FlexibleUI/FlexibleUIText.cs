using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(CollectionItemUI))]
public class FlexibleUIText : FlexibleUI {
    private TextMeshProUGUI textTMP;
    public bool inheritFontSize = true;

    public override void OnSkinUI() {
        base.OnSkinUI();
        textTMP = GetComponent<TextMeshProUGUI>();
        textTMP.font = flexibleUIData.fontAsset;
        textTMP.fontMaterial = flexibleUIData.fontMaterial;
        if(inheritFontSize)textTMP.fontSize = flexibleUIData.fontSize;
    }
}