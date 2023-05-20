using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARScaleController : MonoBehaviour
{
    private Touch touch;
    private float scaleSpeedModifier = 0.001f;

    public float minScale = .1f;
    public float maxScale = 15f;

    public Transform Game;
    public ARChangeElementsController Elements;

    public Slider sliderZoom;
    public List<float> scaleFactor = new List<float>();

    private void Start()
    {
        scaleFactor = Elements.scaleFactor;
        AddListenerToSliderZoom();
    }

    public void AddListenerToSliderZoom()
    {
        sliderZoom.minValue = minScale;
        sliderZoom.maxValue = maxScale;
        //sliderZoom.value = Game.localScale.x;
        sliderZoom.value = 0;
        sliderZoom.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        //Debug.Log(sliderZoom.value);

        if (sliderZoom.value > 0.9f)
            sliderZoom.value = 0.9f;

        float scale = sliderZoom.maxValue - sliderZoom.value;


        ScaleAround(transform, Game.position, new Vector3(scale, scale, scale));
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //rotationY = touch.deltaPosition.x * rotateSpeedModifier;
                //transform.RotateAround(transform.position, transform.up, -rotationY);
                //transform.localRotation= Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationY, transform.localRotation.eulerAngles.z)  ;
            }

            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;
                //float difference = prevMagnitude - currentMagnitude;

                float scale = Mathf.Clamp(transform.localScale.x + difference * scaleSpeedModifier, minScale, maxScale);
                ScaleAround(transform, Game.position, new Vector3(scale, scale, scale));
                //transform.localScale = new Vector3(scale, scale, scale);
            }
        }

    }

    public void ScaleAround(Transform target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.position;
        Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.transform.localScale.x; // relataive scale factor
        RS = RS * scaleFactor[Elements.Counter];
        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.localScale = newScale;
        target.position = FP;
    }
}
