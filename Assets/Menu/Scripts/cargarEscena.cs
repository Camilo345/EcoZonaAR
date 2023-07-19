using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class cargarEscena : MonoBehaviour
{

    public int escena;
    public TMP_Text texto;
    public Slider slider;
    public float porcentaje;
    // Start is called before the first frame update
    void Start()
    {
        escena = PlayerPrefs.GetInt("escena");
        StartCoroutine(LoadEscene());
    }

    IEnumerator LoadEscene()
    {
        yield return new WaitForSeconds(1f);
        texto.text = "Cargando.. 00%";
        AsyncOperation loadAsyinc = SceneManager.LoadSceneAsync(escena);

        while (!loadAsyinc.isDone)
        {
            //  porcentaje = loadAsyinc.progress * 100 / 0.9f;
            porcentaje = loadAsyinc.progress * 100f;
            Debug.Log(porcentaje);
            texto.text = "Cargando.. " + porcentaje.ToString("00") + "%";
            yield return null;
        }
    }

    private void Update()
    {
        slider.value = Mathf.MoveTowards(slider.value, porcentaje, 100);
    }
}
