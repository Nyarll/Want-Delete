using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;

    public float rotateSpeed = 2.0f;

    public float angleLimit = 60;

    float angleH = 0, angleV = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        rotateCamera();
    }

    void rotateCamera()
    {
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        float deltaAngleH = (mouseInputX * 50f / 60f) * rotateSpeed;
        float deltaAngleV = (-mouseInputY * 50f / 60f) * rotateSpeed;

        angleH += deltaAngleH;
        angleV += deltaAngleV;

        float clampAngleV = Mathf.Clamp(angleV, 0, 60);

        float overshootV = angleV - clampAngleV;

        deltaAngleV -= overshootV;
        angleV = clampAngleV;

        Vector3 XRotateAxis = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        XRotateAxis = Quaternion.Euler(0, 90, 0) * XRotateAxis;

        Vector3 RotatePoint = target.transform.position;
        RotatePoint.y += 0.5f;

        // X Axis Rotate
        mainCamera.transform.RotateAround(RotatePoint, XRotateAxis, deltaAngleV);
        // Y Axis Rotate
        mainCamera.transform.RotateAround(RotatePoint, Vector3.up, deltaAngleH);
    }

}
