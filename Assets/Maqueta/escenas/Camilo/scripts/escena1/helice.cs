using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helice : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidad * Vector3.up * Time.deltaTime, Space.World);
    }
}
