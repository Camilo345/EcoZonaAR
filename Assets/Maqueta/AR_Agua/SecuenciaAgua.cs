using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuenciaAgua : MonoBehaviour
{
    [SerializeField] private GameObject[] clips;
    //[SerializeField] private float tiempoEntreClip;
    
    private int index = 0;
    [SerializeField]
    private List<AudioSource> audios;

    private void OnEnable()
    {
       
        rellenarListaAudios();
        desactivarClips();
        clips[index].SetActive(true);
        audios[index].Play();
        Invoke("spawnAndContinue", clips[index].GetComponent<AudioSource>().clip.length);
        index++;
    }

    void Start()
    {
        
    }

    void spawnAndContinue()
    {
        if (clips[index] != null)
        {
            clips[index - 1].SetActive(false);
            clips[index].SetActive(true);
            audios[index].Play();
            Invoke("spawnAndContinue", audios[index].clip.length);
            index++;
        }
    }

   public void desactivarClips()
    {
        index = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            audios[i].Stop();
            clips[i].SetActive(false);
        }
    }

    void rellenarListaAudios()
    {
        audios.Clear();
        CancelInvoke("spawnAndContinue");
        for (int i = 0; i < clips.Length; i++)
        {
            audios.Add(clips[i].GetComponent<AudioSource>());
        }
        desactivarClips();
    }
}
