using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarPanelSeleccio : MonoBehaviour
{
    public controlSeleccionAnimal control;

    public delegate void eventoSeleccion(bool estado);
    public static event eventoSeleccion seleccionado;

    [SerializeField]
    GameObject panlinfo;
    // Start is called before the first frame update
    void Start()
    {
        panlinfo = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarPanel()
    {
        if (control.estaSeleccionado)
        {
            panlinfo.SetActive(true);
        }else
        {
            panlinfo.SetActive(false);
        }
    }


    public void select(bool state)
    {
        seleccionado(state);
        activarPanel();
    }
}
