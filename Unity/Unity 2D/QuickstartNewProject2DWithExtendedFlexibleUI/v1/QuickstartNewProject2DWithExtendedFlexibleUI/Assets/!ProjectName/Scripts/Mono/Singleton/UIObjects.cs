using TMPro;
using UnityEngine;

public class UIObjects : MonoBehaviour {
    public static UIObjects Instance { get; private set; }

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;
    }

    public Canvas UICanvas;
    public TextMeshProUGUI debugText;

    //Menus
    [Header("Menus")]
    public MainMenu mainMenu;
}