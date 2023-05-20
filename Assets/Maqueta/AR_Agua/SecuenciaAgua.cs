using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuenciaAgua : MonoBehaviour
{
    [SerializeField] private GameObject[] clips;
    [SerializeField] private float tiempoEntreClip;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        clips[index].SetActive(true);
        Invoke("spawnAndContinue", tiempoEntreClip);
        index++;
    }

    void spawnAndContinue()
    {
        if (clips[index] != null)
        {
            clips[index - 1].SetActive(false);
            clips[index].SetActive(true);
            index++;
            Invoke("spawnAndContinue", tiempoEntreClip);
        }
    }
}
