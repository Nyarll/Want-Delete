using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform camera;

    [Header("Move")]
    public float walkSpeed = 0.2f;
    public float runSpeed = 0.4f;
    public float jumpPower = 2.0f;

    float moveSpeed;
    bool isJump = false;

    [Header("Dead Line")]
    public float deadHeight = -10f;

    [Header("Look Point")]
    [SerializeField]
    GameObject LookPoint;

    Vector3 respawnPoint;

    float respawnSaveTime = 2;
    float saveDeltaTime = 0;


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

        respawnPoint = transform.position;
        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectionFix();

        IsRun();
        Move();
        Jump();
        
        Fall();

    }

    void Update()
    {
        
    }

    // <移動>
    void Move()
    {
        float InputH = Input.GetAxis("Horizontal");
        float InputV = Input.GetAxis("Vertical");

        Vector3 dir = transform.position - camera.position;
        dir.y = 0;
        dir.Normalize();

        Vector3 velocityV = dir;
        velocityV.Normalize();

        Vector3 velocityH = Quaternion.Euler(0, 90, 0) * dir;
        velocityH.Normalize();

        Vector3 velocity = (velocityV * InputV) + (velocityH * InputH);
        velocity.Normalize();
        velocity *= moveSpeed;

        transform.position += velocity;
    }

    // <ジャンプ>
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJump)
            {
                isJump = true;
                Vector3 jumpVelocity = new Vector3(0, 1, 0) * jumpPower;

                transform.GetComponent<Rigidbody>().velocity = jumpVelocity;
            }
        }
    }

    // <何かに衝突したとき>
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            isJump = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "RespawnPoint")
        {
            if((Input.GetKey(KeyCode.E) || Input.GetMouseButton(0)) && saveDeltaTime <= respawnSaveTime)
            {
                saveDeltaTime += Time.deltaTime;
            }
            else
            {
                saveDeltaTime = 0;
            }

            if (saveDeltaTime >= respawnSaveTime)
            {
                respawnPoint = other.gameObject.transform.position;
                Destroy(other.gameObject);
                saveDeltaTime = 0;
            }
        }
    }

    // <一定の高さ以下まで落下したとき>
    void Fall()
    {
        // <死ぬ高さ未満まで落ちたとき>
        if(transform.position.y < deadHeight)
        {
            // <リスポーンポイントに戻す>
            transform.position = respawnPoint;

            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void IsRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }

    void DirectionFix()
    {
        transform.LookAt(LookPoint.transform);
    }
}
