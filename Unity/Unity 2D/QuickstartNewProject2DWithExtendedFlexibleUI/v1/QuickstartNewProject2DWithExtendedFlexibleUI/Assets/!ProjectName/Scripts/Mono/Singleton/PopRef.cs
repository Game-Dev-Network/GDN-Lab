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

    [Header("Containers")]
    public Transform terrain;
    public Transform structures;
    public Transform characters;
}