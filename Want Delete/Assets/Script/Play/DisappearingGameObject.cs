using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingGameObject : MonoBehaviour
{

    bool isDisable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // <ƒvƒŒƒCƒ„[‚ªG‚Á‚½‚ç>
        if(collision.gameObject.tag == "Player")
        {
            isDisable = true;
            gameObject.SetActive(false);
        }
    }
}
