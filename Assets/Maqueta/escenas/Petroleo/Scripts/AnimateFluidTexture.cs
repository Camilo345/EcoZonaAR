using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFluidTexture : MonoBehaviour
{
    [SerializeField] private float scrollSpeedX = 0.5f;
    [SerializeField] private float scrollSpeedY = 0.5f;
    [SerializeField] private float dirX = 0f;
    [SerializeField] private float dirY = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX*dirX, offsetY*dirY);
    }
}
