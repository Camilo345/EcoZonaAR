using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCharacter : MonoBehaviour
{
    public Transform[] targets;
    public float velocidad = 5.0f;
    public float waitInit = 2.0f;
    public GameObject glass;

    private int currentTargetIndex = 0;
    private float distanciaMinima = 0.1f;
    private bool esperando = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startAnim()
    {
        StartCoroutine(AnimSalida());
    }

    void Update()
    {
        if (!esperando)
        {


            Transform target = targets[currentTargetIndex];

            // Calcula la dirección hacia el objetivo
            Vector3 direccion = target.position - transform.position;

            // Comprueba si la distancia al objetivo es mayor que la distancia mínima
            if (direccion.magnitude > distanciaMinima)
            {
                // Normaliza la dirección para mantener una velocidad constante
                Vector3 movimiento = direccion.normalized * velocidad * Time.deltaTime;

                // Mueve el personaje hacia el objetivo
                float distancia = velocidad * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, distancia);

                // Rota el personaje hacia el objetivo
                transform.rotation = Quaternion.LookRotation(direccion);
            }
            else
            {

                // Comprobamos si estamos en el último destino antes de terminar
                if (currentTargetIndex == targets.Length - 1)
                {
                   
                    esperando = true;
                    StartCoroutine(AnimElevator());
                    

                }
                else
                {
                    // Avanzamos al siguiente destino
                    currentTargetIndex++;
                }

            }
        }


    }

    IEnumerator AnimSalida()
    {
        yield return new WaitForSeconds(waitInit);
        Animation anim = GetComponent<Animation>();
        anim.Play("Run (1)");
        esperando = false;
    }

    IEnumerator AnimElevator()
    {
        Animation anim = GetComponent<Animation>();
        anim.Play("Transformado");
        Animator m_Animator = glass.GetComponent<Animator>();
        m_Animator.SetTrigger("ActiveGlass");

        yield return new WaitForSeconds(0.9f);
        //m_Animator.SetBool("ActiveGlass", false);


        gameObject.SetActive(false);
    }
}
