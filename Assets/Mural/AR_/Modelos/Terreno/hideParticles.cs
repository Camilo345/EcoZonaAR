using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideParticles : MonoBehaviour
{
    private float time;
    ParticleSystem part;
    void Start()
    {
        time = part.main.duration;
        Invoke("hide", time);
    }

    void hide()
    {
        gameObject.SetActive(false);
    }
}
