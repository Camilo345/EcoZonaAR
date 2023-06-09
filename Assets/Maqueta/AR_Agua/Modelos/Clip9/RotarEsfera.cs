using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEsfera : MonoBehaviour
{ 
    [SerializeField] private float velocidadRotacion = 1.0f;

    public enum Eje { x, y, z}

    public Eje EjeRotacion;

    private Vector3 axis = new Vector3(0,0,0);
    private void Start()
    {
        switch (EjeRotacion)
        {
            case Eje.x:
                axis = transform.right;
                break;
            case Eje.y:
                axis = transform.up;
                break;
            case Eje.z:
                axis = transform.forward;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        transform.RotateAround(transform.position, axis, Time.deltaTime * velocidadRotacion);
    }
}

