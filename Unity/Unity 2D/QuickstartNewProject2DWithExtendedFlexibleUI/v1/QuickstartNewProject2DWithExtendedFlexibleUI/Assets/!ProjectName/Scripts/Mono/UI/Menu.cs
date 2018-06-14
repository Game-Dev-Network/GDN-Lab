using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Adds/Removes itself from activeMenus on Enable/Disable
/// </summary>
public abstract class Menu : MonoBehaviour {
    public List<Selectable> Selectables { get; set; }

    /// <summary> Iterate backwards, self removing objects</summary>
    private List<Menu> activeMenus = new List<Menu>();

    private void OnEnable() {
        activeMenus.Add(this);
    }

    private void OnDisable() {
        activeMenus.Remove(this);
    }

    private void Update() {
        if (Selectables != null && Input.GetKeyDown(KeyCode.Tab)) {
            var count = Selectables.Count;
            for (int i = 0; i < count; i++) {
                Selectable selected = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();
                if (Selectables[i] == selected) {
                    if (i == count - 1) break;
                    else Selectables[i + 1].Select();
                    return;
                }
            }
            //if none found or last select first element
            Selectables[0].Select();
        }
    }
}