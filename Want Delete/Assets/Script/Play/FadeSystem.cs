using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{
    // <�t�F�[�h�A�E�g�J�n/����>
    bool isFadeOut = false;
    // <�t�F�[�h�C���J�n/����>
    bool isFadeIn = true;
    // <�V�[���ύX���邩�ǂ���>
    bool isSceneChange = false;

    // <�����x���ς��X�s�[�h>
    [SerializeField]
    float fadeSpeed = 0.75f;

    [SerializeField]
    Image fadeImage;// = this.gameObject.transform.Find("Canvas").transform.Find("Image").GetComponent<Image>();

    float red, green, blue, alpha;

    string nextScene;
    

    // Start is called before the first frame update
    void Start()
    {
        
        SetRGBA(0, 0, 0, 1);

        // <�V�[���J�ڊ�����A�t�F�[�h�C���J�n>
        SceneManager.sceneLoaded += SceneFadeInStart;
    }

    void SceneFadeInStart(Scene sccene, LoadSceneMode mode)
    {
        isFadeIn = true;
        fadeImage.gameObject.SetActive(true);
    }

    public void SceneChange(string next)
    {
        nextScene = next;
        isSceneChange = true;
    }

    public void FadeInStart()
    {
        isFadeIn = true;
        fadeImage.gameObject.SetActive(true);
    }

    public void FadeOutStart(int _red, int _green, int _blue, int _alpha)
    {
        SetRGBA(_red, _green, _blue, _alpha);
        SetColor();
        isFadeOut = true;
        fadeImage.gameObject.SetActive(true);
    }

    public void FadeOutStart()
    {
        FadeOutStart(0, 0, 0, 0);
    }

    bool FadeIn()
    {
        if (isFadeIn)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            SetColor();
            if (alpha <= 0)
            {
                isFadeIn = false;
                Time.timeScale = 1f;
                fadeImage.gameObject.SetActive(false);
                return true;
            }
        }
        return false;
    }

    bool FadeOut()
    {
        if (isFadeOut)
        {
            alpha += fadeSpeed * Time.deltaTime;
            SetColor();
            if (alpha >= 1)
            {
                isFadeOut = false;
                
                return true;
            }
        }
        return false;
    }

    public bool IsFadeIn()
    {
        return isFadeIn;
    }

    public bool IsFadeOut()
    {
        return isFadeOut;
    }

    void FixedUpdate()
    {
        FadeIn();

        if(FadeOut())
        {
            if (isSceneChange)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(nextScene);
                isSceneChange = false;
            }
        }
    }

    void SetColor()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    void SetRGBA(int r, int g, int b, int a)
    {
        red = r;
        green = g;
        blue = b;
        alpha = a;
    }
}
