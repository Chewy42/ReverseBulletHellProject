using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject TouchWheel;
    public GameObject CircleInTouchWheel;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 100;
        maxHealth = 100;
        movement_speed = 5;
    }

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        foreach (Touch touch in Input.touches)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                //set the touch wheel to active
                TouchWheel.SetActive(true);
                // make the rect position of the touch wheel x=0 and y=-410 on screen and not in the world
                TouchWheel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero + new Vector2(0, -410);
                break;
            case TouchPhase.Moved:
                // get the direction of the touch
                Vector2 direction = (touch.position - (Vector2)TouchWheel.transform.position).normalized;

                // clamp the circle's position within the bounds of the touch wheel
                float radius = TouchWheel.GetComponent<RectTransform>().rect.width / 2;
                CircleInTouchWheel.transform.position = Vector2.ClampMagnitude(direction, radius) + (Vector2)TouchWheel.transform.position;

                // move the player in the direction of the touch
                rb.velocity = direction * movement_speed;
                break;
            case TouchPhase.Ended:
                // stop the player
                rb.velocity = Vector2.zero;
                // set the touch wheel to inactive
                TouchWheel.SetActive(false);
                break;
            case TouchPhase.Canceled:
                // The touch has been cancelled. You can stop tracking the touch position here.
                break;
        }
    }
    }
}