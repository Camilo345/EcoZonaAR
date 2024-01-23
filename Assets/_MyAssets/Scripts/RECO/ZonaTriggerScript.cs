using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZonaTriggerScript : MonoBehaviour
{
    private bool actionExecuted = false;
    public string tagElement = "Player";
    public UnityEvent EnterTrigger;
    public UnityEvent ExitTrigger;

    // Este método se llama cuando un objeto entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collider "+other.gameObject.name);
        if (other.CompareTag(tagElement) && !actionExecuted)
        {
            EnterTrigger.Invoke();
            actionExecuted = true;
        }
    }

    // Este método se llama cuando un objeto sale del trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagElement))
        {
            ExitTrigger.Invoke();
            actionExecuted = false;
        }
    }
}
