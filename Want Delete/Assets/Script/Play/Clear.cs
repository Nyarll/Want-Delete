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
        // <�G���^�[�L�[�������ꂽ��>
        if(Input.GetKeyDown(KeyCode.Return))
        {
            FadeSystem fade = GameObject.Find("FadeSystem").GetComponent<FadeSystem>();
            fade.FadeOutStart();
            fade.SceneChange(nextLevelName);

            // <�}�E�X�J�[�\���Œ�����E�\��>
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
