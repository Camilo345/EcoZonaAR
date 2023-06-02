using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salpicadura : MonoBehaviour
{
    public ParticleSystem particulas;
    public float tiempo;

    private void OnEnable()
    {
        llamarPar();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void reproducirPaticulas()
    {
        particulas.Play();
    }

    void llamarPar()
    {
        Invoke("reproducirPaticulas", tiempo);
        Invoke("llamarPar", 7.166f);
    }
}
