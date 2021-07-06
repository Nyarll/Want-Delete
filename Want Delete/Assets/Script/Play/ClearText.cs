using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class ClearText : MonoBehaviour
{

    Text textComponent;
    Color color = Color.red;

    Vector3 deltaColor = new Vector3(255, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.color = color;

        if(deltaColor.x <= 255)
        {
            deltaColor.x += Time.deltaTime;
            deltaColor.z -= Time.deltaTime;
        }
        else if(deltaColor.y <= 255)
        {
            deltaColor.y += Time.deltaTime;
            deltaColor.x -= Time.deltaTime;
        }
        else if(deltaColor.z <= 255)
        {
            deltaColor.z += Time.deltaTime;
            deltaColor.y -= Time.deltaTime;
        }

        if (deltaColor.x < 0)
            deltaColor.x = 0;
        if (deltaColor.y < 0)
            deltaColor.y = 0;
        if (deltaColor.z < 0)
            deltaColor.z = 0;


        color.r = deltaColor.x;
        color.g = deltaColor.y;
        color.b = deltaColor.z;
    }
}
