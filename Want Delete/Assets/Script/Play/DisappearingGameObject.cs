using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingGameObject : MonoBehaviour
{
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
        // <�v���C���[���G�����玩�Ȕj��>
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
