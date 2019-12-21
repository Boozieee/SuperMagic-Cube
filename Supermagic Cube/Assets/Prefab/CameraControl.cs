using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    public Camera ThisCam;
    public float distance = 15.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    private float currentZ = 60.0f;
    public float sensitivityX = 15.0f;
    public float sensitivityY = 15.0f;
    public float sensitivityZ= 25.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentZ = Input.GetAxis("Mouse ScrollWheel") * -1;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        currentZ = Mathf.Clamp(currentZ, -1, 1);
        ThisCam.fieldOfView += currentZ * sensitivityZ;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
        ThisCam.fieldOfView = Mathf.Clamp(ThisCam.fieldOfView, 20, 100);
    }
}
