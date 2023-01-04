using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    private bool isAlreadyDoingDamage = false;
    protected float enemyDamage;
    // while the enemy is colliding with the player do damage every second
    private IEnumerator OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !isAlreadyDoingDamage)
        {
            isAlreadyDoingDamage = true;
            StartCoroutine(DamagePlayer());
            //wait 1 second before doing damage again
            yield return new WaitForSeconds(1f);
            isAlreadyDoingDamage = false;
        }
    }
    private IEnumerator DamagePlayer()
    {
        print("ran");
        Player.Instance.TakeDamage(enemyDamage);
        yield return new WaitForSeconds(1f);
    }
}
