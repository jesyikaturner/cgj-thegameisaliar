using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private Rigidbody rigidBody;
    PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        currentStamina = maxStamina;

        movement = GetComponent<PlayerMovement>();
        movement.rigidBody = rigidBody;
    }

    // Update is called once per frame
    void Update()
    {
        movement.Movement(characterSpeed);
    }
}
