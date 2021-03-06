using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{

    public string nextLevelName = "Title";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // <エンターキーが押されたら>
        if(Input.GetKeyDown(KeyCode.Return))
        {
            FadeSystem fade = GameObject.Find("FadeSystem").GetComponent<FadeSystem>();
            fade.FadeOutStart();
            fade.SceneChange(nextLevelName);

            // <マウスカーソル固定解除・表示>
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
