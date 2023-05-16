using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunSwipeManager : MonoBehaviour
{
    [Header("System Swipe")]
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        // * Mouse Inputs
        MouseInputs();

        // * Mobile Input
        // MobileInput();


        // * calculate the distance
        CalculateDistance();

        // * Did we cross the distance?
        GetDistance();

    }

    private void MouseInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
    }

    private void MobileInput()
    {
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            tap = true;
            isDraging = true;
            startTouch = Input.touches[0].position;
        }
        else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
        {
            isDraging = false;
            Reset();
        }
    }

    private void CalculateDistance()
    {
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
    }

    private void GetDistance()
    {
        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // * left or right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                // * up or down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();

        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

}
