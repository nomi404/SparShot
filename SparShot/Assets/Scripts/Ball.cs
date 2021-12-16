using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Set this to true for your top-half player, and false for the bottom-half player.
    public bool topHalfIsMine;

    public float Power = 10f;
    public float maxDrag = 5f;

    Rigidbody2D rb;
    Vector2 dragStartPos;

    int activeTouchId = -1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        if (activeTouchId < 0)
        {
            TryStartTouch();
        }
        else
        {
            TrackTouch();
        }
    }

    void TryStartTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);

            // Skip touches that are not new.
            if (touch.phase != TouchPhase.Began) continue;

            // Check which half of the screen the touch started on.
            bool onBottomHalf = touch.position.y < (Screen.height / 2);

            // Can I claim this touch as being in my half of the screen?
            bool mine = onBottomHalf ^ topHalfIsMine;

            // If not, skip it.
            if (!mine) continue;

            // Otherwise, this is my touch. Record its information.
            activeTouchId = touch.fingerId;
            dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);

         
            break;
        }
    }

    void TrackTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            // Iterate through the touches till we find the one we claimed.
            var touch = Input.GetTouch(i);
            if (touch.fingerId != activeTouchId) continue;

            // Process the touch depending on its phase.
            switch (touch.phase)
            {
                case TouchPhase.Moved:

                    // Update our line when it moves.
                    Vector2 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);

                   
                    // Are you sure you don't want to be setting position 1 here?
                  

                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    // Clear our active touch when it ends.
                    activeTouchId = -1;


                    Vector2 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);

                    Vector2 force = dragStartPos - dragReleasePos;
                    Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * Power;
                    rb.AddForce(clampedForce, ForceMode2D.Impulse);

                    break;
            }
            return;
        }
    }


}
