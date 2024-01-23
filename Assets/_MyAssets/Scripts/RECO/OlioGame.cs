using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OlioGame : MonoBehaviour
{
    public float increaseRate = 1.0f; // Velocidad de aumento del progreso
    private float currentProgress = 0f; // Progreso actual
    private bool isIncreasing = false;

    public UnityEvent FinishEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing)
        {
            currentProgress += increaseRate * Time.deltaTime;

            if(currentProgress >= 10.0f)
            {
                FinishEvent.Invoke();
                isIncreasing = false;
                currentProgress = 0f;
            }
        }
    }

    public void changeState(bool mystate)
    {
        isIncreasing = mystate;
    }
}
