using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class instruccionesEspecies : MonoBehaviour
{
    public GameObject BotonFoto;
    public GameObject BotonInfo;

    public GameObject TextInstrucciones1;
    public GameObject TextInstrucciones2;

    public GameObject objIndicador;

    private bool mostrarIns = true;
    public Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        activarUI(false);
        initialPos = objIndicador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //bool tiene = obtenerHijo();
        if(mostrarIns && objIndicador.transform.position== initialPos)
        {
           
            activarInstrucciones(true, false);
        }else if (mostrarIns && objIndicador.transform.position != initialPos)
        {
           
            activarInstrucciones(false, true);
        }
        else
        {
            activarInstrucciones(false, false);
        }
    }

    bool obtenerHijo()
    {
        bool tienePadre = true;
       
        try
        {
            Debug.Log(objIndicador.transform.parent.gameObject);
        }
        catch (Exception ex)
        {
            tienePadre = false;
        }
        return tienePadre;
    }

    void activarUI(bool estado)
    {
        BotonFoto.SetActive(estado);
        BotonInfo.SetActive(estado);
    }

    void activarInstrucciones(bool estado1, bool estado2)
    {
        TextInstrucciones1.SetActive(estado1);
        TextInstrucciones2.SetActive(estado2);
    }

    public void desactivarTodo()
    {
        mostrarIns = false;
        activarUI(true);
    }
}
