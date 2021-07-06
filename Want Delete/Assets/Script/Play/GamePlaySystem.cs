using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // <マウスカーソル固定・非表示>
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<ScreenShot>().PrintScreen();
        }
    }
}
