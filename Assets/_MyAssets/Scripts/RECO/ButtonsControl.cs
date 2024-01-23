using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonsControl : MonoBehaviour
{

    public int totalButtons = 4; // Cantidad botones.
    public UnityEvent CompletedButtons;
    private int buttonsPressed = 0;


    // Funci�n llamada cuando se presiona un bot�n.
    public void OnButtonPressed()
    {
        buttonsPressed++;

        // Si se han presionado todos los botones, activa una funci�n.
        if (buttonsPressed == totalButtons)
        {
            CompletedButtons.Invoke();
        }
    }

   
}
