using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NumbreIncrease : MonoBehaviour
{
    public float increaseRate = 1.0f; // Velocidad de aumento del n�mero
    private float currentNumber = 0f; // N�mero actual
    public TextMeshProUGUI textoObservaciones;
    private TextMeshProUGUI textMesh; 
    private bool reachedLimit = false;

    public UnityEvent CompletedLimit;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!reachedLimit)
        {
            // Aumenta el n�mero linealmente con el tiempo
            currentNumber += increaseRate * Time.deltaTime;

            // Muestra el n�mero en el TextMeshPro
            textMesh.text = Mathf.RoundToInt(currentNumber).ToString() + "m"; // Ajusta el formato como desees

            if (Mathf.RoundToInt(currentNumber) == 2000)
            {
                textoObservaciones.text = "Hemos llegado a zona segura";
            }

            // Verifica si se alcanz� el l�mite
            if (currentNumber >= 3000)
            {
                reachedLimit = true;
                textoObservaciones.text = "�Hemos llegado a nuestro destino!";
                // Activa el evento de Unity aqu�
                CompletedLimit.Invoke();


            }
        }
    }
}