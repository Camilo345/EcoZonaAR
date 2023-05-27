using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEsfera : MonoBehaviour
{
    //var to set the coin rotation spedd in Inspector
    [SerializeField]
    //1.0f rotattions/sec
    private float rotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //starts the Coroutine
        StartCoroutine(Spin());
    }
    //to spin the coin.All Coroutines must have a return Type IEnumerator
    private IEnumerator Spin()
    {
        //to rotate smootly a bit on each frame
        while (true)
        {
            //transform.Rotate => transform function from Rotate class
            //transform.up => along y axis
            //Time.deltaTime => how much time since last frame
            //360 * rotateSpeed * Time.deltaTime => how much i nedd to rotate each frame
            transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
            // to avoid eternal loop
            yield return 0;
        }
    }
}

