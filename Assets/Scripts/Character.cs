using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDestroyableObject
{
    public float maxHealth;
    public float currentHealth;
    public float maxStamina;
    public float currentStamina;
    public float characterSpeed;

    // Takes value damage, if health goes below 0 then the character is destroyed.
    public void TakeDamage(float value)
    {
        if (currentHealth > 0)
        {
            currentHealth -= value;
        }
        else
        {
            Debug.Log("Character dies.");
            DestroySelf();
        }
    }

    // returns a bool so that if player does have enough stamina, it will allow the move.
    public bool UseStamina(float value)
    {
        // if 100 < 10 - 100  then should return false;
        if(value <= currentStamina)
        {
            currentStamina -= value;
            return true;
        }
        /*
        if(currentStamina > 0)
        {
            currentStamina -= value;
            return true;
        }*/
        return false;
    }

    public void GainHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void GainStamina(float value)
    {
        currentStamina += value;
        if (currentStamina > maxHealth)
        {
            currentStamina = maxStamina;
        }
    }

    // Virtual so that I can override in the player/ enemies
    public virtual void DestroySelf()
    {
        Destroy(obj: gameObject);
    }

}
