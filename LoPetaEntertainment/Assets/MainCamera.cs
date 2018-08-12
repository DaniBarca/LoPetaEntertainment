using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private static MainCamera _instance;
    public static MainCamera Instance { get { return _instance; } private set { _instance = value; } }

    public float MAP_SIZE = 128.0f;
    public float ICEBERG_SIZE = 64.0f;
    
    public float CAMERA_POSITION_RANGE_HORIZONTAL = 20.0f;
    public float CAMERA_POSITION_RANGE_VERTICAL   = 20.0f;

    public GameObject follow;

    private Vector3 originPosition;
    private Vector3 targetPosition;
    private Vector3 lastUpdatePosition;
    private float lastUpdateTime;
    private float cameraLerpTime = 0.05f;

    private void Awake()
    {
        UnityEngine.Assertions.Assert.IsTrue(_instance == null);
        Instance = this;
    }

    void Start () {
        originPosition = transform.position - Vector3.forward * 10.0f;
        targetPosition = originPosition;
        lastUpdatePosition = targetPosition;
        lastUpdateTime = Time.time;
    }

    void Update () {
        transform.position = Vector3.Lerp(lastUpdatePosition, targetPosition, (Time.time - lastUpdateTime) / cameraLerpTime);
	}

    public void UpdateFollowCamera()
    {
        Vector2 relativeXY = new Vector2(
            0.5f - 0.5f * Mathf.Cos(Mathf.PI * 0.5f + Mathf.PI * (-0.5f + (follow.transform.position.x + ICEBERG_SIZE * 0.5f) / ICEBERG_SIZE)),
            0.5f - 0.5f * Mathf.Cos(Mathf.PI * 0.5f + Mathf.PI * (-0.5f + (follow.transform.position.z + ICEBERG_SIZE * 0.5f) / ICEBERG_SIZE))
        );

        targetPosition = new Vector3(
            originPosition.x - Mathf.Lerp(-CAMERA_POSITION_RANGE_HORIZONTAL, CAMERA_POSITION_RANGE_HORIZONTAL, relativeXY.x),
            transform.position.y,
            originPosition.z - Mathf.Lerp(-CAMERA_POSITION_RANGE_VERTICAL, CAMERA_POSITION_RANGE_VERTICAL, relativeXY.y)
        );

        lastUpdatePosition = transform.position;
        lastUpdateTime = Time.time;
    }
}
