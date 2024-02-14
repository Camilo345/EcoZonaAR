using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] escenas;
    [SerializeField] private float[] tiempos;
    [SerializeField] private float delayInicio = 3f;
    [SerializeField] private GameObject Base;
    private int indexGlobal = 0;

    private void Start()        //Comentar este bloque para exportar, aquí se invoca Inicio() desde el start solo para hacer
    {                           //las pruebas en el editor
        Inicio();
    }

    public void Inicio()
    {
        Base.SetActive(true);
        Invoke("stepSecuencia", delayInicio);
    }

    void stepSecuencia()
    {
            StartCoroutine(activarEscena(indexGlobal));
    }
    private IEnumerator activarEscena(int index)
    {
        if(index==0)
        {
            escenas[index].SetActive(true);
        }
        else
        {
            escenas[index - 1].SetActive(false);
            escenas[index].SetActive(true);
        }
        yield return new WaitForSeconds(tiempos[index]);
        
        if (indexGlobal < escenas.Length)
        {
            indexGlobal++;
            stepSecuencia();
        }
    }
}
