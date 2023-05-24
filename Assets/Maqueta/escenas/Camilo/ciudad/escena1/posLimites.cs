using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posLimites : MonoBehaviour
{
    public bool esUno;

    public List<Material> listaMaterial;
    public List<Material> listaMaterial2;
    public GameObject limite1;
    public GameObject limite2;
    public GameObject centro;
    // Start is called before the first frame update
    void Start()
    {
        asignarLimites();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void asignarLimites()
    {
        if (esUno) 
        {
            for (int i = 0; i < listaMaterial.Count; i++)
            {
                listaMaterial[i].SetFloat("_pos2", limite1.transform.position.z);
                listaMaterial[i].SetFloat("_pos", limite2.transform.position.z);
                listaMaterial[i].SetVector("_pos_1", centro.transform.position);
            }
        }
        Invoke("asignarLimites", 0.2f);
       
    }
}
