using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helice : MonoBehaviour
{
    public float velocidad;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidad * dir * Time.deltaTime, Space.World);
    }
}
