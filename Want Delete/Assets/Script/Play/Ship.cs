using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 0.1f;
    [SerializeField]
    float addTime = 1.0f;

    float time = 0;

    Vector3 start, end;

    float moveDir = 0;


    // Start is called before the first frame update
    void Start()
    {
        Transform parent = transform.parent;
        start = parent.Find("Start").transform.position;
        end = parent.Find("End").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        float moveDirection = Mathf.Sin(moveDir);
        moveDir += Time.deltaTime;


        Vector3 moveVelociy = end - start;
        moveVelociy.Normalize();
        moveVelociy *= moveSpeed * moveDirection;


        transform.position += moveVelociy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var parent = collision.gameObject.transform.parent;
            parent.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var parent = collision.gameObject.transform.parent;
            parent.SetParent(null);
        }
    }
}
