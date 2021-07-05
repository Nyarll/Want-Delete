using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;

    public float rotateSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }

    void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed,
            Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        mainCamera.transform.RotateAround(target.transform.position, Vector3.up, angle.x);
        //mainCamera.transform.RotateAround(target.transform.position, transform.right, angle.y);
    }
}
