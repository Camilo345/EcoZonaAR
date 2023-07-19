using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMiraCamara : MonoBehaviour
{

    Transform camara;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newRotation = new Vector3(45, 0, 0);
        transform.localEulerAngles = newRotation;
        camara = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       //transform.LookAt(new Vector3(transform.position.x, transform.position.y, camara.position.z));
    }
}
