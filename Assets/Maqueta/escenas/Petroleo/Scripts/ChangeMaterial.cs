using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] newMaterials;

    public void Change()
    {
        Debug.Log("Iniciando renderer ");
        Renderer rend = GetComponent<MeshRenderer>();
        Debug.Log("Meterial renderer " + rend.material.name);

        if (rend != null)
        {
            rend.materials = newMaterials;
            Debug.Log("Material Cambiado ");
        }
        else
        {
            Debug.LogError("El objeto no tiene un componente Renderer.");
        }
    }
}
