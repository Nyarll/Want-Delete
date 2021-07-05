using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform camera;
    private Vector3 forword;
    private Vector3 vel;
    private Vector3 Animdir = Vector3.zero;

    float runSpeed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        if(Camera.main != null)
        {
            camera = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Warning: No main camera found ! Third person character needs a Camera tagged.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(camera != null)
        {
            forword = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
            vel = v * forword * runSpeed + h * camera.right * runSpeed;
        }

        transform.position = new Vector3
            (
            transform.position.x + vel.x,
            0,
            transform.position.z + vel.z
            );

        Vector3 AnimDir = vel;
        AnimDir.y = 0;

        if(AnimDir.sqrMagnitude > 0.001)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, AnimDir, 5f * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    void Update()
    {
        
    }
}
