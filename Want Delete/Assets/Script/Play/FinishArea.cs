using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    [Header("���̃��x��")]
    [SerializeField]
    string NextLevel = "Title";

    [Header("�N���AUI")]
    [SerializeField]
    GameObject clearUIPrefab;

    GameObject clearUIInstance;

    // Start is called before the first frame update
    void Start()
    {
        clearUIInstance = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (clearUIInstance == null)
            {
                clearUIInstance = GameObject.Instantiate(clearUIPrefab) as GameObject;
            }
        }
    }
}
