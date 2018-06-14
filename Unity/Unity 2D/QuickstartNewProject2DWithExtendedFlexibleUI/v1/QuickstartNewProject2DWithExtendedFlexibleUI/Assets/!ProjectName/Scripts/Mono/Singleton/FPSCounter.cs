using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI)), RequireComponent(typeof(CollectionItemUI)), RequireComponent(typeof(FlexibleUIText))]
public class FPSCounter : MonoBehaviour {
    public static FPSCounter Instance { get; private set; }

    private const float fpsMeasurePeriod = 0.5f;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;
    private const string display = "FPS {0}";
    private TextMeshProUGUI textTMP;

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;
    }

    [RuntimeInitializeOnLoadMethod]
    private void Start() {
        m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
        textTMP = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        m_FpsAccumulator++;
        if (Time.realtimeSinceStartup > m_FpsNextPeriod) {
            m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += fpsMeasurePeriod;
        }
        textTMP.text = string.Format(display, m_CurrentFps);
    }
}