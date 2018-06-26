using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Persistant Objects (popular) References
/// </summary>
[ExecuteInEditMode]
public class PopRef : MonoBehaviour {
    public static PopRef Instance { get; private set; }

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;
    }

    [Header("UI Settings")]
    [Header("Persistant Objects References")]
    public ThemeSwap themeSwap;
    public TMP_FontAsset fontAsset;
    public List<FlexibleUIData> allThemes;

    [Header("Containers")]
    public Transform terrain;
    public Transform structures;
    public Transform characters;

    private void OnValidate() {
        //Cleanup deleted Themes
        foreach (var item in allThemes) if (item == null) allThemes.Remove(item);
    }
}