using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform camera;

    public float runSpeed = 0.2f;
    public float jumpPower = 2.0f;

    bool isJump = false;


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
        Move();
        Jump();
    }

    void Update()
    {
        
    }

    void Move()
    {
        float InputH = Input.GetAxis("Horizontal");
        float InputV = Input.GetAxis("Vertical");

        Vector3 dir = transform.position - camera.position;
        dir.y = 0;

        Vector3 velocityV = dir;
        velocityV.Normalize();
        velocityV *= runSpeed;

        Vector3 velocityH = Quaternion.Euler(0, 90, 0) * dir;
        velocityH.Normalize();
        velocityH *= runSpeed;

        transform.position += velocityV * InputV;
        transform.position += velocityH * InputH;
    }

    void Jump()
    {
        if(!isJump && Input.GetKey(KeyCode.Space))
        {
            isJump = true;
            Vector3 jumpVelocity = new Vector3(0, 1, 0) * jumpPower;

            transform.GetComponent<Rigidbody>().velocity = jumpVelocity;
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            isJump = false;
        }
    }
}
