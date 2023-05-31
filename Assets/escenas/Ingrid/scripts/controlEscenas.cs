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
        //desactivarEscenas(false);
      //  listaEscenas[0].SetActive(true);
        
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
    //    listaEscenas[escenaActual].SetActive(false);
      //  escenaActual = 0;
       // audioActual = 0;
    }

    public void pasarEscena()
    {
        listaEscenas[escenaActual].SetActive(false);
        escenaActual++;
        listaEscenas[escenaActual].SetActive(true);
    }
    public void pasarAudio()
    {
        audioSou.Stop();
        audioSou.clip = listaAudios[audioActual];
        audioSou.Play();
       // audioSou.PlayOneShot(listaAudios[audioActual]);
        audioActual++;
    }

    void desactivarEscenas(bool estado)
    {

        for(int i = 0; i < listaEscenas.Count; i++)
        {
            listaEscenas[i].SetActive(estado);
        }
    }

    public void pausar()
    {
        //listaEscenas[escenaActual].SetActive(false);
        audioSou.Stop();
        //escenaActual = 0;
        if(escenaActual>0)
        audioActual--;
    }

    public void reiniciar()
    {
        desactivarEscenas(false);
        listaEscenas[0].SetActive(true);
        escenaActual = 0;
        audioActual = 0;
    }
}
