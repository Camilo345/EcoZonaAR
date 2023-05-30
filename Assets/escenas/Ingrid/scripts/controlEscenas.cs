using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEscenas : MonoBehaviour
{
    public AudioSource audioSou;
    public List<AudioClip> listaAudios;
    public List<GameObject> listaEscenas;
    public bool esElMapa = false;
    public int escenaActual = 0;
    public int audioActual = 0;
    private void OnEnable()
    {
        listaEscenas[0].SetActive(true);
        if (esElMapa)
        {
            desactivarEscenas(true);
        }
        pasarEscen.pasarEscena += pasarEscena;
        pasarEscen.pasarAudio += pasarAudio;
    }

    private void OnDisable()
    {
        pasarEscen.pasarEscena -= pasarEscena;
        pasarEscen.pasarAudio -= pasarAudio;
        desactivarEscenas(false);
        escenaActual = 0;
        audioActual = 0;
    }

    public void pasarEscena()
    {
        listaEscenas[escenaActual].SetActive(false);
        escenaActual++;
        listaEscenas[escenaActual].SetActive(true);
    }
    public void pasarAudio()
    {
        audioSou.PlayOneShot(listaAudios[audioActual]);
        audioActual++;
    }

    void desactivarEscenas(bool estado)
    {

        for(int i = 0; i < listaEscenas.Count; i++)
        {
            listaEscenas[i].SetActive(estado);
        }
    }
}
