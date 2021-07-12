using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySystem : MonoBehaviour
{

    [Header("Object to be reappeared")]
    [SerializeField]
    GameObject disappearingObjects;
    [SerializeField]
    GameObject respawnPointObjects;

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<ScreenShot>().PrintScreen();
        }

        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
    }

    public void PlayerFalls()
    {
        // <再出現>
        foreach(Transform item in disappearingObjects.transform)
        {
            item.gameObject.SetActive(true);
        }

        foreach(Transform respawn in respawnPointObjects.transform)
        {
            respawn.gameObject.SetActive(true);
        }
    }
}
