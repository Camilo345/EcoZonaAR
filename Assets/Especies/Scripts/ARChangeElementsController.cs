using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ARChangeElementsController : MonoBehaviour
{

    public List<GameObject> elements;
    [TextArea(1, 20)]
    public List<string> nombreElements;
    [TextArea(1,20)]
    public List<string> infoElements;
    public List<float> scaleFactor;

    public TMP_Text textNombre;
    public TMP_Text textInfo;
    public UnityEvent OnChangeElement;

    public int Counter = 0;

    void Start()
    {
        foreach (GameObject element in elements)
        {
            element.SetActive(false);
        }
        int animal = PlayerPrefs.GetInt("animal");
        textNombre.text = nombreElements[animal];
        textInfo.text = infoElements[animal];
        elements[animal].SetActive(true);

    }

    private void Update()
    {
      
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
