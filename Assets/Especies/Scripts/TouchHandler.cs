/*==============================================================================
Copyright (c) 2021 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
==============================================================================*/

using UnityEngine;
using TMPro;
public class TouchHandler : MonoBehaviour
{
    public Transform AugmentationObject;
    public bool EnablePinchScaling;

    public static bool sIsSingleFingerStationary => IsSingleFingerDown() && Input.GetTouch(0).phase == TouchPhase.Stationary;
    public static bool sIsSingleFingerDragging => IsSingleFingerDown() && Input.GetTouch(0).phase == TouchPhase.Moved;
    static int sLastTouchCount;

    const float SCALE_RANGE_MIN = 0.1f;
    const float SCALE_RANGE_MAX = 2.0f;

    Touch[] mTouches;
    public bool mEnableRotation;
    bool mIsFirstFrameWithTwoTouches;
    float mCachedTouchAngle;
    float mCachedTouchDistance;
    float mCachedAugmentationScale;
    Vector3 mCachedAugmentationRotation;
    Vector3 posTocuh = Vector3.zero;

    /// <summary>
    /// Enables rotation input.
    /// It is registered to ContentPositioningBehaviour.OnContentPlaced.
    /// </summary>
    public void EnableRotation()
    {
        mEnableRotation = true;
    }

    /// <summary>
    /// Disables rotation input.
    /// It is registered to UI Reset Button and also DevicePoseBehaviourManager.DevicePoseReset event.
    /// </summary>
    public void DisableRotation()
    {
        mEnableRotation = false;
    }

    void Start()
    {
        mCachedAugmentationScale = AugmentationObject.localScale.x;
        mCachedAugmentationRotation = AugmentationObject.localEulerAngles;
    }

    void Update()
    {
        if (Input.touchCount <2)
        {
            
            Touch touch = Input.GetTouch(0);
            Vector3 dir = Vector3.zero;
            
            if (touch.phase == TouchPhase.Began)
            {
                posTocuh = touch.position;
               
            }
            if (touch.phase == TouchPhase.Moved)
            {
                

                if (touch.position.x < posTocuh.x)
                {
                    dir.y = -1;
                }
                else
                {
                    dir.y = 1;
                }
                AugmentationObject.localEulerAngles += mCachedAugmentationRotation - new Vector3(0, dir.y * 80f * Time.deltaTime, 0);
            }
        }
    }

    void GetTouchAngleAndDistance(Touch firstTouch, Vector3 secondTouch, out float touchAngle, out float touchDistance)
    {
        touchDistance = Vector2.Distance(firstTouch.position, secondTouch);
        var diffY = firstTouch.position.y - secondTouch.y;
        var diffX = firstTouch.position.x - secondTouch.x;
        touchAngle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg;
    }

    static bool IsSingleFingerDown()
    {
        if (Input.touchCount == 0 || Input.touchCount >= 2)
            sLastTouchCount = Input.touchCount;

        return Input.touchCount == 1 && Input.GetTouch(0).fingerId == 0 && sLastTouchCount == 0;
    }
}