using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            float offset = Time.time * scrollSpeed;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
        }
        
    }

    public void changeRunning(bool running)
    {
        isRunning = running;
    }
}