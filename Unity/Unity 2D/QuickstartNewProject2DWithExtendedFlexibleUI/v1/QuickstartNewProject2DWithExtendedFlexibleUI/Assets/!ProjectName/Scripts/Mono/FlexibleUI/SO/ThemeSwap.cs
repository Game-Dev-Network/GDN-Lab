using UnityEngine;

[CreateAssetMenu(menuName = "Custom/UI/ThemeSwap")]
public class ThemeSwap : ScriptableObject {
    private FlexibleUIData[] previousFlexibleUIData;

    [Tooltip("Determines which theme is used for new items")]
    public int activeIndex = 0;
    public FlexibleUIData[] allFlexibleUIData;

    private void OnEnable() {
        previousFlexibleUIData = allFlexibleUIData.Clone() as FlexibleUIData[];
    }

    private void OnValidate() {
        Swap();
    }

    public void Swap() {
        if ((previousFlexibleUIData == null) || (allFlexibleUIData.Length != previousFlexibleUIData.Length)) OnEnable();
        for (int i = 0; i < allFlexibleUIData.Length; i++) {
            if (allFlexibleUIData[i] != previousFlexibleUIData[i]) {
                for (int j = 0; j < previousFlexibleUIData[i].allUIObjects.Items.Count; j++) {
                    CollectionItemUI collectionItemUI = (CollectionItemUI)previousFlexibleUIData[i].allUIObjects.Items[j];
                    collectionItemUI.allUIObjects = allFlexibleUIData[i].allUIObjects;
                    collectionItemUI.allUIObjects.Add(collectionItemUI);
                    FlexibleUI flexibleUI = collectionItemUI.GetComponent<FlexibleUI>();
                    flexibleUI.flexibleUIData = allFlexibleUIData[i];
                    flexibleUI.OnSkinUI();
                }
                previousFlexibleUIData[i].allUIObjects.Items.Clear();
            }
        }

        int count = allFlexibleUIData.Length;
        for (int i = 0; i < count; i++) {
            ItemsCollectionUI allUIObjects = allFlexibleUIData[i].allUIObjects;
            int subCount = allUIObjects.Items.Count - 1;
            for (int j = subCount; j >= 0; j--) {
                //take out leftover empty items
                if (allUIObjects.Items[j] == null) {
                    allUIObjects.Remove(allUIObjects.Items[j]);
                    continue;
                }
                ((CollectionItemUI)allUIObjects.Items[j]).GetComponent<FlexibleUI>().flexibleUIData = allFlexibleUIData[i];
            }
        }

        for (int i = 0; i < allFlexibleUIData.Length; i++) {
            previousFlexibleUIData[i] = allFlexibleUIData[i];
        }
    }
}