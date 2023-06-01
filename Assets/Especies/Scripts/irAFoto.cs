using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class irAFoto : MonoBehaviour
{
    public int animal = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEscena(int esc)
    {
        PlayerPrefs.SetInt("animal", animal);
        SceneManager.LoadScene(esc);
    }

    public void cambiarAnimal(int ani)
    {
        animal = ani;
    }
}
