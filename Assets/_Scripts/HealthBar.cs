using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private GameObject healthBarPrefab;

    [SerializeField]
    private GameObject healthBarContainer;

    [SerializeField]
    private float healthBarSize = 0.5f;

    protected float maxHealth;
    protected float currentHealth;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public float Health
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    
}
