using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenXP : XP
{
    //set xp amount
    void Start()
    {
        xpAmount = 1;
    }

    // if circle collider is triggered by player, add xp to player
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.AddXP(xpAmount);
            Destroy(gameObject);
        }
    }
}
