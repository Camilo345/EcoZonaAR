using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuenciaAgua : MonoBehaviour
{
    [SerializeField] private GameObject[] clips;
    //[SerializeField] private float tiempoEntreClip;
    private int index = 0;

    void Start()
    {
        clips[index].SetActive(true);
        Invoke("spawnAndContinue", clips[index].GetComponent<AudioSource>().clip.length);
        index++;
    }

    void spawnAndContinue()
    {
        if (clips[index] != null)
        {
            clips[index - 1].SetActive(false);
            clips[index].SetActive(true);
            Invoke("spawnAndContinue", clips[index].GetComponent<AudioSource>().clip.length);
            index++;
        }
    }
}
