using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseWaterSplash : MonoBehaviour
{
    [SerializeField] private ParticleSystem partic = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rio")
        {
            Debug.Log("Trigger");
            partic.Play();
        }
    }
}
