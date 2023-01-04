using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private bool DEBUG = false;

    // Movement Variables
    public GameObject TouchWheel;
    public GameObject CircleInTouchWheel;
    public SpriteRenderer PlayerSprite;

    // XP Variables
    public float currentXP;
    private float nextLevelXP;

    // Player Variables
    private float level;


    // Create Instance
    public static Player Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 100;
        maxHealth = 100;
        movement_speed = 5;
        currentXP = 0;
        nextLevelXP = 5;
        level = 0;
        if(DEBUG){
            Debug.Log("Player Health: " + health);
            Debug.Log("Player Max Health: " + maxHealth);
            Debug.Log("Player Movement Speed: " + movement_speed);
            Debug.Log("Player Current XP: " + currentXP);
            Debug.Log("Player Next Level XP: " + nextLevelXP);
            Debug.Log("Player Level: " + level);
        }
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
                // move the circle in the touch wheel in the direction of the touch, but do not let the circle leave the touch wheel
                CircleInTouchWheel.GetComponent<RectTransform>().anchoredPosition = Vector2.ClampMagnitude(touch.position - new Vector2(Screen.width / 2, Screen.height / 2), 100);
                // move the player in the direction of the touch
                rb.velocity = (touch.position - new Vector2(Screen.width / 2, Screen.height / 2)).normalized * movement_speed;
                //flip sprite based on direction of movement
                if (rb.velocity.x > 0)
                {
                    PlayerSprite.flipX = false;
                }
                else if (rb.velocity.x < 0)
                {
                    PlayerSprite.flipX = true;
                }
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
    public GameObject GetParent()
    {
        GameObject parent = null;
        if (transform.parent!= null)
        {
            parent = transform.parent.gameObject;
        }
        return parent;
    }

    public float GetHealth(){
        if(DEBUG){
            Debug.Log("Player Health: " + health);
        }
        return health;
    }

    public float GetMaxHealth(){
        if(DEBUG){
            Debug.Log("Player Max Health: " + maxHealth);
        }
        return maxHealth;
    }

    public float AddXP(float xp){
        currentXP += xp;
        if(DEBUG){
            Debug.Log("Player Current XP: " + currentXP);
            Debug.Log("Player Next Level XP: " + nextLevelXP);
        }
        if (currentXP >= nextLevelXP){
            if(DEBUG){
                Debug.Log("Player Level Up!");
            }
            LevelUp();
        }
        return currentXP;
    }

    private void LevelUp(){
        level++;
        currentXP = 0;
        nextLevelXP = nextLevelXP * 1.5f;
        if(DEBUG){
            Debug.Log("Player Level: " + level);
            Debug.Log("Player Current XP: " + currentXP);
            Debug.Log("Player Next Level XP: " + nextLevelXP);
        }
    }

    public void TakeDamage(float damage){
        health -= damage;
        if(DEBUG){
            Debug.Log("Player Health: " + health);
        }
    }

}