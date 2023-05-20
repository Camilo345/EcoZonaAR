using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disolverGota : MonoBehaviour
{
    public Material materialGota;
    public float dissolveRatio;

    private float dissolve = 0;
   

    private bool canDissolve = false;
    // Start is called before the first frame update
    void Start()
    {
        materialGota.SetFloat("_dissolve", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDissolve)
        {
            dissolve += dissolveRatio *  Time.deltaTime;
            materialGota.SetFloat("_dissolve", dissolve);
        }
        if (dissolve > 1.2f)
        {
            canDissolve = false;
        }
    }

    public void disolver()
    {
        canDissolve = true;
    }
}
