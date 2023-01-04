using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField]
    protected Slider HealthBarSlider;
    [SerializeField]
    protected Image HealthBarFill;

    public Player Player;
    protected float currentHealth;
    protected float maxHealth;
    
    void Update(){
        currentHealth = Player.GetHealth();
        maxHealth = Player.GetMaxHealth();
        CorrectHealthBarColor();
    }

    protected void TakeDamage(float damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            currentHealth = 0;
            //Die();
        }
        CorrectHealthBarColor();
        HealthBarSlider.value = currentHealth;
    }

    private void CorrectHealthBarColor(){
        // get the percentage of health at 60 percent
        float sixtyPercentHealth = maxHealth / 60f;
        float thirtyPercentHealth = maxHealth / 30f;

        print("SIXTY PERCENT HEALTH: " + sixtyPercentHealth);
        if(currentHealth >= sixtyPercentHealth){
            HealthBarFill.color = Color.green;
        }else if(currentHealth < sixtyPercentHealth && currentHealth >= thirtyPercentHealth){
            HealthBarFill.color = Color.yellow;
        }else{
            HealthBarFill.color = Color.red;
        }
    }

}
