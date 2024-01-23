using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonsControl : MonoBehaviour
{

    public int totalButtons = 4; // Cantidad botones.
    public UnityEvent CompletedButtons;
    private int buttonsPressed = 0;


    // Función llamada cuando se presiona un botón.
    public void OnButtonPressed()
    {
        buttonsPressed++;

        // Si se han presionado todos los botones, activa una función.
        if (buttonsPressed == totalButtons)
        {
            CompletedButtons.Invoke();
        }
    }

   
}
