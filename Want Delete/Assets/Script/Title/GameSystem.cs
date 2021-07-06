using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // <�^�C�g���ɖ߂�>
    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }

    // <�Q�[���X�^�[�g>
    public void GameStart()
    {
        SceneManager.LoadScene("TestPlay");
        Time.timeScale = 1f;
    }

    // <�Q�[���I��>
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
