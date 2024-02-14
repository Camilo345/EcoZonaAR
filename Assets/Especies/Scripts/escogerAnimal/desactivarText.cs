using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivarText : MonoBehaviour
{
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void desactivar(bool estado)
    {
        texto.SetActive(estado);
    }
}
