using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cambiarItemMenu : MonoBehaviour
{
    public List<Color> listaColore;
    public List<Image> listaImagenes;
    public Scrollbar scrollbar;
    public int pos = 0;
    public float posObjetivo;

    private int dir =1;
    private Touch touch;
    private float timeTouchEnd;
    private Vector2 startPos, EndPos;
    private float displayTime = 0.5F;
    // Start is called before the first frame update
    void Start()
    {
        cambiarCirculos();
    }

    // Update is called once per frame
    void Update()
    {
        verificarSwipe();
        if (Input.GetKeyDown(KeyCode.A))
        {
            pasarItem(-1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pasarItem(1);
        }

        if (scrollbar.value < posObjetivo-0.05 || scrollbar.value> posObjetivo+0.05f)
        {
            scrollbar.value += dir * Time.deltaTime;
        }
        else
        {
            scrollbar.value = posObjetivo;
        }
        
       // scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[pos], 1f * Time.deltaTime);
    }

    void pasarItem(int incremento)
    {
        int posAux = pos;
        pos += incremento;
        if(pos<0 || pos > 2)
        {
            pos = posAux;
            
        }
        else
        {
            if (incremento > 0)
            {
                dir = 1;
                posObjetivo += 0.5f;
            }
            else
            {
                dir = -1;
                posObjetivo -= 0.5f;
            }
        }
    }

   public void cambiarCirculos()
    {
       int posA = (int)(2* scrollbar.value);
        for(int i = 0; i < 3; i++)
        {
            if (i == posA)
            {
                listaImagenes[i].color = listaColore[0];
            }
            else
            {
                listaImagenes[i].color = listaColore[1];
            }
        }
    }

    void verificarSwipe()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase== TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if(touch.phase==TouchPhase.Ended)
            {
                EndPos = touch.position;
                float x = EndPos.x - startPos.x;

                if(x >0)
                {
                    pasarItem(-1);
                }
                else
                {
                    pasarItem(1);
                }
            }
        }
    }
}
