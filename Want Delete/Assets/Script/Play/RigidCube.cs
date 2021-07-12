using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidCube : MonoBehaviour
{

    Vector3 spawnPoint;
    Quaternion spawnRotation;


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        spawnRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < -30f)
        {
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
            var rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
            
        }
    }
}
