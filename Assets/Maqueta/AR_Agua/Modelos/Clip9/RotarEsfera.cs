using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEsfera : MonoBehaviour
{ 
    [SerializeField]
    private float velocidadRotacion = 1.0f;

    public enum Eje { x, y, z}

    public Eje EjeRotacion;


    private void Update()
    {
        switch (EjeRotacion)
        {
            case Eje.x:
                transform.RotateAround(transform.position, transform.right, Time.deltaTime * velocidadRotacion);
                break;
            case Eje.y:
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * velocidadRotacion);
                break;
            case Eje.z:
                transform.RotateAround(transform.position, transform.forward, Time.deltaTime * velocidadRotacion);
                break;
            default:
                break;
        }
    }
}

