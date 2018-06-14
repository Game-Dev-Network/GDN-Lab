using UnityEngine;

public class FollowCamera2D : MonoBehaviour {
    public static FollowCamera2D Instance { get; private set; }

    internal Camera Camera;
    internal float zOffset = -10f;
    private Transform T;
    public Transform TrackTarget { get; set; }

    private void Awake() {
        //Singleton code
        if (Instance != null && Instance != this) Debug.LogError("Trying to instantiate a second singleton", gameObject);
        else Instance = this;

        T = transform;
        Camera = GetComponent<Camera>();
    }

    private void Start() {
        if (TrackTarget == null) Debug.LogFormat(this, "<color=red> Camera script FollowCamera2D requires a target to follow </color>");
    }

    private void LateUpdate() {
        if (TrackTarget != null) T.position = TrackTarget.position + new Vector3(0, 0, zOffset);
    }
}