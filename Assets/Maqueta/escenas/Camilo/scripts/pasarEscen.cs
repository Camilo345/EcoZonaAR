using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasarEscen : MonoBehaviour
{

    public delegate void eventoPasarEscena();
    public static event eventoPasarEscena pasarEscena;

    public delegate void eventoPasarAudio();
    public static event eventoPasarAudio pasarAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pasar()
    {
        pasarEscena();
    }

    public void pasarAud()
    {
        pasarAudio();
    }
}
