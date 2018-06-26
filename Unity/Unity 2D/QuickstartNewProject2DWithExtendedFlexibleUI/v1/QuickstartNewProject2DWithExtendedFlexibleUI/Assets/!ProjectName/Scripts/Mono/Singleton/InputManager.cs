using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public static InputManager Instance { get; private set; }

    public bool LockControls { get; set; } = false;

    public KeyCode fullScreenKey = KeyCode.F;

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;
    }

    private IEnumerator Start() {
        UIObjects.Instance.UICanvas.gameObject.SetActive(true);
        UIObjects.Instance.mainMenu.gameObject.SetActive(true);
        Debug.LogFormat(this, "<color=blue>Remove following loop to stop demo</color>");
        UIObjects.Instance.debugText.text = "Playing demo";
        while (true) {
            for (int i = 0; i < PopRef.Instance.allThemes.Count; i++) {
                PopRef.Instance.themeSwap.allFlexibleUIData[0] = PopRef.Instance.allThemes[i];
                PopRef.Instance.themeSwap.Swap();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    private void Update() {
        if (!LockControls) {
            //Controls input
            if (Input.GetKeyDown(KeyCode.Mouse0)) { }

            PixelPerfectCamera.Instance.pixelScale += Input.GetAxis("Mouse ScrollWheel");
            PixelPerfectCamera.Instance.pixelScale = Mathf.Clamp(PixelPerfectCamera.Instance.pixelScale, PixelPerfectCamera.minRange, PixelPerfectCamera.maxRange);
        }

        //Escape Menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Quit();
        }
    }

    public void GameStart() {
    }

    public void Quit() {
        Application.Quit();
        if (!Application.isEditor) System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}