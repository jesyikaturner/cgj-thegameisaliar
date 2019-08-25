using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDestroyableObject
{
    public float maxHealth;
    public float currentHealth;

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            Debug.Log("Character dies.");
            DestroySelf();
        }
    }

    // Virtual so that I can override in the objects
    public virtual void DestroySelf()
    {
        Destroy(obj: gameObject);
    }
}
