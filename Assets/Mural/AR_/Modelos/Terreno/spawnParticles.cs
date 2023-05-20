using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnParticles : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    private Animator globalVolume;

    private void Start()
    {
        globalVolume = GameObject.FindGameObjectWithTag("globalVolume").GetComponent<Animator>();
        globalVolume.Play("globalAnim");
    }

    void spawnP()
    {
        //Instantiate(particles, transform.position, Quaternion.identity);
        particles.gameObject.SetActive(true);
    }

}
