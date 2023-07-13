using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMiraCamara : MonoBehaviour
{

    Transform camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(camara.position.x, transform.position.y, transform.position.z));
    }
}
