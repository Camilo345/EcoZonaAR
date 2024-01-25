using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeEvent : MonoBehaviour
{
    public float time = 5.0f;
    public UnityEvent TimeEnded;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(time);

        TimeEnded.Invoke();
    }

}
