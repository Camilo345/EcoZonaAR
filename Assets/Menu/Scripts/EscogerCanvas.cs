using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscogerCanvas : MonoBehaviour
{
    public GameObject canvasMobile;
    public GameObject canvasTablet;
    // Start is called before the first frame update
    void Start()
    {
        
        escoger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void escoger()
    {
        float width = Screen.width;
        float height = Screen.height;
        float aspectRatio = height / width;

        canvasMobile.SetActive(false);
        canvasTablet.SetActive(false);

        if (aspectRatio < 1.4f)
        {
            canvasTablet.SetActive(true);
        }
        else
        {
            canvasMobile.SetActive(true);
        }
    }

}
