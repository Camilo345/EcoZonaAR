using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerMapa : MonoBehaviour
{
    public GameObject mapa;
    public GameObject holograma;
    public float timeMap;
    // Start is called before the first frame update
    void Start()
    {
        mapa.SetActive(false);
        holograma.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void eventoMapa()
    {
        holograma.SetActive(true);
        Invoke("activarMapa", timeMap);
    }

    void activarMapa()
    {
        mapa.SetActive(true);
       
    }
}
