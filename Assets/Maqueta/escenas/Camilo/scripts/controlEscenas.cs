using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEscenas : MonoBehaviour
{
    public List<GameObject> listaEscenas;
    public int escenaActual = 0;

    private void OnEnable()
    {
        pasarEscen.pasarEscena += pasarEscena;
    }

    private void OnDisable()
    {
        pasarEscen.pasarEscena -= pasarEscena;
    }

    void pasarEscena()
    {
        listaEscenas[escenaActual].SetActive(false);
        escenaActual++;
        listaEscenas[escenaActual].SetActive(true);
    }
}
