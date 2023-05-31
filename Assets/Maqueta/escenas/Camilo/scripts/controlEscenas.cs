using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEscenas : MonoBehaviour
{
    public AudioSource audioSou;
    public List<AudioClip> listaAudios;
    public List<GameObject> listaEscenas;
    public int escenaActual = 0;
    public int audioActual = 0;
    private void OnEnable()
    {
        pasarEscen.pasarEscena += pasarEscena;
        pasarEscen.pasarAudio += pasarAudio;
    }

    private void OnDisable()
    {
        pasarEscen.pasarEscena -= pasarEscena;
        pasarEscen.pasarAudio -= pasarAudio;
    }

    void pasarEscena()
    {
        listaEscenas[escenaActual].SetActive(false);
        escenaActual++;
        listaEscenas[escenaActual].SetActive(true);
    }
    void pasarAudio()
    {
        audioSou.PlayOneShot(listaAudios[audioActual]);
        audioActual++;
    }
}
