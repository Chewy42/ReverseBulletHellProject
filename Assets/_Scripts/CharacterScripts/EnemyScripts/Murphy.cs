using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murphy : EnemyCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 10f;
        maxHealth = GameParameters.MURPHY_MAX_HEALTH;
        movement_speed = GameParameters.MURPHY_MOVEMENT_SPEED;
        enemyDamage = GameParameters.MURPHY_DAMAGE;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    //method to constantly move towards the player
    private void MoveTowardsPlayer()
    {
        //get the player's position
        Vector2 playerPosition = Player.Instance.transform.position;
        //get the direction to the player
        Vector2 direction = playerPosition - (Vector2)transform.position;
        //normalize the direction
        direction.Normalize();
        //move towards the player
        rb.velocity = direction * movement_speed;
    }
}
