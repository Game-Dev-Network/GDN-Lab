using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class PixelPerfectCamera : MonoBehaviour {
    public static PixelPerfectCamera Instance { get; private set; }

    public const float minRange = .25f;
    public const float maxRange = 1f;
    [Range(minRange, maxRange)]
    public float pixelScale = 1;

    private int pixelsPerUnit = 100;
    private float halfScreen = 0.5f;

    private Camera cameraMain;

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;
        cameraMain = GetComponent<Camera>();
        cameraMain.orthographic = true;
    }

    private IEnumerator Start() {
        while (true) {
            cameraMain.orthographicSize = Screen.height * ((halfScreen / pixelsPerUnit) / pixelScale);
            yield return new WaitForEndOfFrame();
        }
    }
}