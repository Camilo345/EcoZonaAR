using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerParticulas : MonoBehaviour
{
    public ParticleSystem particulas;
    public GameObject gota;
    // Start is called before the first frame update
    void Start()
    {
        particulas.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void emitir()
    {
        gota.SetActive(false);
        particulas.gameObject.SetActive(true);

    }

  
}
