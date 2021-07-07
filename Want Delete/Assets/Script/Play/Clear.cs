using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{

    [SerializeField]
    string nextLevelName = "Title";

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
            SceneManager.LoadScene(nextLevelName);
            // <�}�E�X�J�[�\���Œ�����E�\��>
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}