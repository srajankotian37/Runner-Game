using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    #region Instance
    private static SwipeControls instance;
    public static SwipeControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeControls>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeControls", typeof(SwipeControls)).GetComponent<SwipeControls>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    private float deadzone = 5f;

    public bool swipeleft, swiperight;
    private Vector2 swipedelta, starttouch;
    private float lasttap;
    private float sqrdeadzone;

    #region public properties
    public Vector2 Swipedelta { get { return swipedelta; } }
    public bool Swipeleft { get { return swipeleft; } }
    public bool Swiperight { get { return swiperight; } }
    #endregion

    private void Start()
    {
        sqrdeadzone = deadzone * deadzone;
    }

    public void LateUpdate()
    {
        swipeleft = swiperight = false;

        UpdateInput();
    }

    public void UpdateInput()
    {
        // Reset swipe delta and start touch
        swipedelta = Vector2.zero;

        // Check for left and right arrow key inputs
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            swipeleft = true;
            starttouch = new Vector2(-1, 0); // Dummy start touch position
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            swiperight = true;
            starttouch = new Vector2(1, 0); // Dummy start touch position
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            starttouch = swipedelta = Vector2.zero;
        }

        // Simulate swipe delta based on key inputs
        if (starttouch != Vector2.zero)
        {
            if (starttouch.x < 0)
            {
                swipedelta = new Vector2(-deadzone, 0); // Simulate left swipe
            }
            else if (starttouch.x > 0)
            {
                swipedelta = new Vector2(deadzone, 0); // Simulate right swipe
            }

            // Check if swipe delta exceeds the deadzone
            if (swipedelta.sqrMagnitude > sqrdeadzone)
            {
                if (swipedelta.x < 0)
                {
                    swipeleft = true;
                }
                else if (swipedelta.x > 0)
                {
                    swiperight = true;
                }

                // Reset start touch and swipe delta
                starttouch = swipedelta = Vector2.zero;
            }
        }
    }
}
