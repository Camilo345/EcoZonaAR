using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autos : MonoBehaviour
{

    public float tiempo = 0;
    private void OnEnable()
    {
       Invoke("desactivar", 5);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (transform.position.z > limit1.transform.position.z && transform.position.z < limit2.transform.position.z)
        {
            transform.localPosition += Vector3.forward * Time.deltaTime * velocidad * dir;
        }
        else
        {
            gameOb*ject.SetActive(false);
        }*/
    }

    void desactivar()
    {
        this.gameObject.SetActive(false);
    }
}
