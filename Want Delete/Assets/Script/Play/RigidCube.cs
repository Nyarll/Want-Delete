using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidCube : MonoBehaviour
{

    Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < -30f)
        {
            transform.position = spawnPoint;
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
