/*==============================================================================
Copyright (c) 2021 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
==============================================================================*/

using UnityEngine;

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
    Vector3 posTocuh;
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
   
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                posTocuh = Input.GetTouch(0).position;
            }

            Vector3 dir = Vector3.zero;
            //  var angleDelta = currentTouchAngle - mCachedTouchAngle;
            if (Input.GetTouch(0).position.x < posTocuh.x)
            {
                dir.y = -1;
            }
            else
            {
                dir.y = 1;
            }
            if (mEnableRotation)
            {
                AugmentationObject.Rotate(15 * dir * Time.deltaTime, Space.Self);
                //   AugmentationObject.localEulerAngles += mCachedAugmentationRotation - new Vector3(0,dir * 3f*Time.deltaTime, 0);
            }


            // Optional Pinch Scaling can be enabled via Inspector for this Script Component

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