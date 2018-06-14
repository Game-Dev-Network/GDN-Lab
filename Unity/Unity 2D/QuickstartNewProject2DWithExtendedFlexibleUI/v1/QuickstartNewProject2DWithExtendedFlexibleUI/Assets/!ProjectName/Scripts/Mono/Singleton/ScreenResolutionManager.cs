using System.Collections;
using UnityEngine;

/// <summary>
/// Main purpose is to restore resolution in fullscreen mode after the window has been resized
/// </summary>
public class ScreenResolutionManager : MonoBehaviour {
    public static ScreenResolutionManager Instance { get; private set; }

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;
    }

    private Resolution originalResolution;
    private Resolution maxResolution;

    private IEnumerator Start() {
        originalResolution = new Resolution {
            width = Screen.width,
            height = Screen.height
        };
        maxResolution = Screen.resolutions[Screen.resolutions.Length - 1];

        while (true) {
            if (Screen.fullScreen == false) {
                while (true) {
                    if (Screen.fullScreen == true) {
                        Resolution maxRes = Screen.resolutions[Screen.resolutions.Length - 1];
                        Screen.SetResolution(maxRes.width, maxRes.height, true);
                        break;
                    }
                    yield return new WaitForFixedUpdate();
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void Update() {
        //Fullscreen
        if (Input.GetKeyDown(InputManager.Instance.fullScreenKey)) {
            Resolution currentResolution = new Resolution {
                width = Screen.width,
                height = Screen.height
            };

            if (currentResolution.IsEqual(originalResolution)) {
                Screen.SetResolution(maxResolution.width, maxResolution.height, true);
            }
            else {
                Screen.SetResolution(originalResolution.width, originalResolution.height, false);
            }
        }
    }
}