using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerAutos1 : MonoBehaviour
{
    public List<GameObject> listaCarros1;
    // Start is called before the first frame update
    void Start()
    {
        desactivarAutos1(listaCarros1);
        Invoke("llamarCarro", Random.Range(1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void llamarCarro()
    {
        activarCarro1();
        Invoke("llamarCarro", Random.Range(1, 3));
    }

    void activarCarro1()
    {
        bool salir = false;
        while (!salir)
        {
            int r = Random.Range(0, listaCarros1.Count);
            if (!listaCarros1[r].activeInHierarchy)
            {
                listaCarros1[r].SetActive(true);
                salir = true;
            }
        }
        /*for(int i = 0; i < listaCarros1.Count; i++)
        {
            if (!listaCarros1[i].activeInHierarchy)
            {
                
                break;
            }
        }*/
    }

    void desactivarAutos1(List<GameObject> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            lista[i].SetActive(false);
        }
    }
}
