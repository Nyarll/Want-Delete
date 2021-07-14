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
        SceneManager.sceneLoaded += FadeInStart;
    }

    void FadeInStart(Scene sccene, LoadSceneMode mode)
    {
        isFadeIn = true;
        fadeImage.gameObject.SetActive(true);
        //Debug.Log("Fade In Start !");
    }

    public void FadeOutStart(int _red, int _green, int _blue, int _alpha, string next)
    {
        SetRGBA(_red, _green, _blue, _alpha);
        SetColor();
        isFadeOut = true;
        nextScene = next;
        fadeImage.gameObject.SetActive(true);
        //Debug.Log("Fade Out Start !");
    }

    public void FadeOutStart(string next)
    {
        FadeOutStart(0, 0, 0, 0, next);
    }

    void FixedUpdate()
    {
        if(isFadeIn)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            SetColor();
            if(alpha <= 0)
            {
                isFadeIn = false;
                Time.timeScale = 1f;
                fadeImage.gameObject.SetActive(false);
                //Debug.Log("Fade In Success !");
            }
        }
        if(isFadeOut)
        {
            alpha += fadeSpeed * Time.deltaTime;
            SetColor();
            if(alpha >= 1)
            {
                isFadeOut = false;
                //Debug.Log("Fade Out Success !");
                Time.timeScale = 1f;
                SceneManager.LoadScene(nextScene);
                //fadeImage.gameObject.SetActive(false);
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
