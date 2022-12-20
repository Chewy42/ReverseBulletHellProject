using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    void Start()
    {
        maxHealth = 100f;
        currentHealth = 100f;
    }
    
}
