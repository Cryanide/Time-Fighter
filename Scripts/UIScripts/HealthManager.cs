using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // are you a player or an enemy?
    public bool isPlayer;
    public bool isEnemy;

    // gets current entity's health values
    public float currentHealth;
    public float maxHealth;
    public float currentStamina;
    public float maxStamina;
    public float regen;

    // can the entity regen it's health/stamina?
    public bool canHealthRegen;
    public bool canStaminaRegen;

    // Update is called once per frame
    void Update()
    {
        // kill entity when it's health is at or below 0
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        // to prevent health/stamina from going over the limit
        if (currentHealth > maxHealth) currentHealth = maxHealth;


        if (currentStamina > maxStamina) currentStamina = maxStamina;

        // regeneration code will go here when/if implemented
        if (canHealthRegen)
        {

        }
        if (canStaminaRegen)
        {
            currentStamina += 0.02f;
        }
    }

    // damage is taken when one entity clashes with another
    void OnTriggerEnter(Collider col)
    {
        if (isPlayer && col.tag == "Enemy")
        {
            //currentHealth -= 10;
        }

        // damage dealt to an enemy once we implement attacks 
        if (isEnemy && col.tag == "Player")
        {

        }
    }
}
