using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarAnimal : MonoBehaviour
{
    public List<GameObject> listaAnimales;
    public ARChangeElementsController controlerAnimales;

    private void OnEnable()
    {
        listaAnimales = controlerAnimales.elements;
        int animal = PlayerPrefs.GetInt("animal");
        listaAnimales[animal].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
