using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform camera;

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
        float InputH = Input.GetAxis("Horizontal");
        float InputV = Input.GetAxis("Vertical");

        Vector3 dir = transform.position - camera.position;
        dir.y = 0;

        Vector3 velocityV = dir;
        velocityV.Normalize();
        velocityV /= 5f;

        Vector3 velocityH = Quaternion.Euler(0, 90, 0) * dir;
        velocityH.Normalize();
        velocityH /= 5f;

        transform.position += velocityV * InputV;
        transform.position += velocityH * InputH;
    }

    void Update()
    {
        
    }
}
