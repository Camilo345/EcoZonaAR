using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour
{
    [SerializeField] private float time = 5f;

    void Start()
    {
        Invoke("despawn", time);
    }

    void despawn()
    {
        GameObject.Destroy(gameObject);
    }
}
