using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    [Header("Start Game Level")]
    [SerializeField]
    public string GameLevelName = "Level0";

    FadeSystem fadeSystem;

    // Start is called before the first frame update
    void Start()
    {
        fadeSystem = GameObject.Find("FadeSystem").GetComponent<FadeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // <�^�C�g���ɖ߂�>
    public void ChangeTitle()
    {
        Time.timeScale = 1f;
        fadeSystem.FadeOutStart("Title");
        //SceneManager.LoadScene("Title");
    }

    // <�Q�[���X�^�[�g>
    public void GameStart()
    {
        Time.timeScale = 1f;
        fadeSystem.FadeOutStart(GameLevelName);
        //SceneManager.LoadScene(GameLevelName);
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
