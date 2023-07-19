using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSeleccionAnimal : MonoBehaviour
{
    public bool estaSeleccionado=false;

    void OnEnable()
    {
        activarPanelSeleccio.seleccionado += cambiarBoolSeleccion;    
    }

    private void OnDisable()
    {
        activarPanelSeleccio.seleccionado -= cambiarBoolSeleccion;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cambiarBoolSeleccion(bool estado)
    {
        estaSeleccionado = estado;
    }
}
