using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    // <�|�[�Y���ɕ\������UI�v���n�u>
    GameObject pauseUIPrefab;
    // <�|�[�YUI�̃C���X�^���X>
    GameObject pauseUIInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseUIInstance == null)
            {
                string nowSceneName = SceneManager.GetActiveScene().name;

                pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                var system = pauseUIInstance.transform.Find("System").GetComponent<GameSystem>();
                system.GameLevelName = nowSceneName;

                Time.timeScale = 0f;

                // <�}�E�X�J�[�\���Œ�����E�\��>
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Destroy(pauseUIInstance);
                Time.timeScale = 1f;

                // <�}�E�X�J�[�\���Œ�E��\��>
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
