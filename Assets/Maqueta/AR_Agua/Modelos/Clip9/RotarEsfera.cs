using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEsfera : MonoBehaviour
{ 
    [SerializeField] private float velocidadRotacion = 1.0f;

<<<<<<< HEAD
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
=======
    // Start is called before the first frame update
    //void Start()
    //{
    //    //starts the Coroutine
    //    StartCoroutine(Spin());
    //}

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotateSpeed);
    }

    //to spin the coin.All Coroutines must have a return Type IEnumerator
    //private IEnumerator Spin()
    //{
    //    //to rotate smootly a bit on each frame
    //    while (true)
    //    {
    //        //transform.Rotate => transform function from Rotate class
    //        //transform.up => along y axis
    //        //Time.deltaTime => how much time since last frame
    //        //360 * rotateSpeed * Time.deltaTime => how much i nedd to rotate each frame
    //        transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
    //        // to avoid eternal loop
    //        yield return 0;
    //    }
    //}
>>>>>>> origin/dev_opc
}

