using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterSequence : MonoBehaviour
{
    public Transform[] personajes;
    public Transform[] targets;
    public GameObject effects;
    public float velocidad = 5.0f;
    public float esperaPorSegundos = 2.0f; // Tiempo de espera en segundos
    public AudioSource EffectAudio;


    private float distanciaMinima = 0.1f;
    private int currentCharacterIndex = 0;
    private int currentTargetIndex = 0;
    public bool esperando = true;
    public UnityEvent CompletedSequence;

    void Start()
    {
        //changeAnimation("Run (1)");
    }

    public void startAnim()
    {
        esperando = false;
        changeAnimation("Run (1)");
    }

    private void changeAnimation(string animName)
    {
        Transform character = personajes[currentCharacterIndex].Find("MiniReco");
        Animation anim = character.gameObject.GetComponent<Animation>();
        //anim.clip = anim.GetClip(animName);

        anim.Play(animName);
    }

    void Update()
    {
        if (!esperando)
        {

            Transform character = personajes[currentCharacterIndex];
            Transform target = targets[currentTargetIndex];

            // Calcula la dirección hacia el objetivo
            Vector3 direccion = target.position - character.position;

            // Comprueba si la distancia al objetivo es mayor que la distancia mínima
            if (direccion.magnitude > distanciaMinima)
            {
                // Normaliza la dirección para mantener una velocidad constante
                Vector3 movimiento = direccion.normalized * velocidad * Time.deltaTime;

                // Mueve el personaje hacia el objetivo
                float distancia = velocidad * Time.deltaTime;
                character.position = Vector3.MoveTowards(character.position, target.position, distancia);

                // Rota el personaje hacia el objetivo
                character.rotation = Quaternion.LookRotation(direccion);
            }
            else
            {

                // Comprobamos si estamos en el último destino antes de esperar
                if (currentTargetIndex == targets.Length - 1)
                {
                    effects.SetActive(true);
                    StartCoroutine(EsperarYAvanzar());
                    esperando = true;
                }
                else
                {
                    // Avanzamos al siguiente destino
                    currentTargetIndex++;
                }

            }
        }


    }

    IEnumerator EsperarYAvanzar()
    {
        changeAnimation("Idle");
        EffectAudio.Play();
        yield return new WaitForSeconds(esperaPorSegundos);

        // Desactivamos efecto máquina      
        effects.SetActive(false);
        EffectAudio.Stop();


        //Activar - desactivar modelos de RECO
        Transform MiniReco = personajes[currentCharacterIndex].Find("MiniReco");

        if (MiniReco != null)
        {
            MiniReco.gameObject.SetActive(false);
        }

        Transform Reco99 = personajes[currentCharacterIndex].Find("Reco99");
        OutCharacter animScript = null;

        if (Reco99 != null)
        {
            Reco99.gameObject.SetActive(true);
            animScript = Reco99.gameObject.GetComponent<OutCharacter>();
        }

        yield return new WaitForSeconds(2.0f);


        //Continuar Camino de Salida
        if (animScript != null)
        {
            animScript.startAnim();
        }

        currentTargetIndex = 0; // Reiniciamos al principio de la lista de destinos.

        // Comprobamos si hemos completado el recorrido de todos los personajes
        if (currentCharacterIndex == personajes.Length - 1)
        {
            esperando = true;
            CompletedSequence.Invoke();
            // Reiniciamos al primer personaje.
            //currentCharacterIndex = 0;
        }
        else
        {
            currentCharacterIndex++;
            esperando = false;
            changeAnimation("Run (1)");
        }
    }
}