using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transeuntesCaminado : MonoBehaviour
{
    public float velocidad;
    public float dir;

    public GameObject limit1;
    public GameObject limit2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z>limit1.transform.position.z && transform.position.z < limit2.transform.position.z)
        {
            transform.localPosition += Vector3.forward * Time.deltaTime * velocidad * dir;
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}
