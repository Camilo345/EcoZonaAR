using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ARChangeElementsController : MonoBehaviour
{
    
    public List<GameObject> elements;
    public List<string> infoElements;
    public List<float> scaleFactor;
    public Text textInfo;
    public UnityEvent OnChangeElement;

    public int Counter = 0;

    void Start()
    {
        foreach (GameObject element in elements)
        {
            element.SetActive(false);
        }
        int animal = PlayerPrefs.GetInt("animal");
        textInfo.text = infoElements[animal];
        elements[animal].SetActive(true);

    }

    public void ActiveNextElement()
    {
        elements[Counter].SetActive(false);
        Counter = Counter == elements.Count - 1 ? 0 : Counter + 1;

       

        elements[Counter].SetActive(true);
        textInfo.text = infoElements[Counter]; 
        OnChangeElement.Invoke();
    }

    public void ActivePrevElement()
    {
        elements[Counter].SetActive(false);
        Counter =  Counter == 0 ? elements.Count - 1 : Counter - 1;

       

        elements[Counter].SetActive(true);  
        textInfo.text = infoElements[Counter];
        OnChangeElement.Invoke();
    }

}
