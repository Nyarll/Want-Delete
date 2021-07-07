using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    [Header("Start Game Level")]
    [SerializeField]
    public string GameLevelName = "TestPlay";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // <タイトルに戻る>
    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }

    // <ゲームスタート>
    public void GameStart()
    {
        SceneManager.LoadScene(GameLevelName); ;
        Time.timeScale = 1f;
    }

    // <ゲーム終了>
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
