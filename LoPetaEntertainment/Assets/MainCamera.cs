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
    public float cameraLerpSpeed = 20.0f;
    public float cameraFollowZDelay = 5.0f;
    public float cameraFollowRotationZDelay = 5.0f;

    private void Awake()
    {
        UnityEngine.Assertions.Assert.IsTrue(_instance == null);
        Instance = this;
    }

    void Start () {
        originPosition = transform.position - Vector3.forward * 10.0f;
        targetPosition = originPosition;
    }

    void Update () {
        targetPosition = Vector3.Scale(Vector3.up, transform.position) + Vector3.Scale(Vector3.right + Vector3.forward, follow.transform.position);
        targetPosition.z -= cameraFollowZDelay;

        Vector3 lookAtPosition = new Vector3(
            follow.transform.position.x,
            0.0f,
            follow.transform.position.z - cameraFollowRotationZDelay
        );
        Quaternion targetRotation = Quaternion.FromToRotation(transform.forward, (lookAtPosition - transform.position).normalized);


        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * cameraLerpSpeed);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraLerpSpeed);
    }

}
