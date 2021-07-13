using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeatbBallGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject deathBallPrefab;

    [SerializeField]
    float spawnInterval = 2.0f;

    float count = 0;

    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(count > spawnInterval)
        {
            count = 0;

            GameObject ball = GameObject.Instantiate(deathBallPrefab) as GameObject;
            var position = getRandomPoint();

            ball.transform.position = position + transform.parent.position; ;
        }

        count += Time.deltaTime;
    }

    Vector3 getRandomPoint()
    {
        float randX = localScale.x / 2;
        float randY = localScale.y / 2;
        float randZ = localScale.z / 2;

        return new Vector3(Random.Range(-randX, randX), Random.Range(-randY, randY), Random.Range(-randZ, randZ));
    }
}
