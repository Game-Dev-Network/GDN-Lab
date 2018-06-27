using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/UI/ThemeSwap")]
public class ThemeSwap : ScriptableObject {
    private List<FlexibleUIData> previousFlexibleUIData;
    private PopRef popRef;

    [ReadOnlyTextArea(2)]
    public string note = "Adding more than one of the same Theme is disallowed because it will merge their contents!";

    [Tooltip("Determines which theme is used for new items")]
    public int activeIndex = 0;
    public List<FlexibleUIData> allFlexibleUIData;

    private void OnEnable() {
        if (popRef == null) popRef = FindObjectOfType<PopRef>();

        previousFlexibleUIData = allFlexibleUIData.ToList();
    }

    private void OnValidate() {
        Swap();
    }

    public void Swap() {
        if (previousFlexibleUIData == null) OnEnable();

        //Adds unique themes to the new elements
        if (allFlexibleUIData.Count > previousFlexibleUIData.Count) {
            //if there are no spare themes
            if (allFlexibleUIData.Count > popRef.allThemes.Count) {
                allFlexibleUIData = previousFlexibleUIData.ToList();
                Debug.LogError("Themes cannot be used twice due to unique collections, create new Theme first", popRef.allThemes[0]);
            }
            else {
                int indexLimit = allFlexibleUIData.Count;
                allFlexibleUIData = previousFlexibleUIData.ToList();
                foreach (var item in popRef.allThemes) {
                    if (!allFlexibleUIData.Contains(item)) {
                        allFlexibleUIData.Add(item);
                        if (allFlexibleUIData.Count == indexLimit) break;
                    }
                }
                OnEnable();
            }
        }
        else if (allFlexibleUIData.Count < previousFlexibleUIData.Count) OnEnable();
        //Check for repeating Theme usage, reset if not unique
        else {
            bool allUnique = allFlexibleUIData.GroupBy(x => x).All(g => g.Count() == 1);
            if (!allUnique) {
                allFlexibleUIData = previousFlexibleUIData.ToList();
                Debug.LogError("Not allowed to use the same Theme twice. This will merge collections", this);
            }
        }

        for (int i = 0; i < allFlexibleUIData.Count; i++) {
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

        int count = allFlexibleUIData.Count;
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

        for (int i = 0; i < allFlexibleUIData.Count; i++) {
            previousFlexibleUIData[i] = allFlexibleUIData[i];
        }
    }
}