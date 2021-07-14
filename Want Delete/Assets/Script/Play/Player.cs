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

    bool isFall = false;

    [Header("Dead Line")]
    public float deadHeight = -10f;

    [Header("Look Point")]
    [SerializeField]
    GameObject LookPoint;

    [Header("GameSystem")]
    [SerializeField]
    GameObject system;

    Vector3 firstRespawnPoint;
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
        firstRespawnPoint = respawnPoint;
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

    // <�ړ�>
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

    // <�W�����v>
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

    // <�����ɏՓ˂����Ƃ�>
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
                other.gameObject.SetActive(false);
                saveDeltaTime = 0;
            }
        }
    }

    // <���̍����ȉ��܂ŗ��������Ƃ�>
    void Fall()
    {
        FadeSystem fade = GameObject.Find("FadeSystem").GetComponent<FadeSystem>();

        // <���ʍ��������܂ŗ������Ƃ�>
        if (transform.position.y < deadHeight)
        {
            isFall = true;

            //fade.FadeOutStart();

            //if(!fade.IsFadeOut() && isFall)
            {
                isFall = false;

                // <���X�|�[���|�C���g�ɖ߂�>
                transform.position = respawnPoint;

                // <���p�ł��郊�X�|�[��������>
                respawnPoint = firstRespawnPoint;

                GetComponent<Rigidbody>().velocity = Vector3.zero;

                system.GetComponent<GamePlaySystem>().PlayerFalls();

                //fade.FadeInStart();
            }
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
