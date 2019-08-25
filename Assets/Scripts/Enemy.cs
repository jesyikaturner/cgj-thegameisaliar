using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public string id;
    public float staminaGainAmount = 0.5f;
    public float healthGainAmount = 0.5f;
    public Transform target;
    public Vector3 startPosition;


    public enum Behaviour
    {
        Look,
        Attack,
        Flee
    }
    public Behaviour behaviour;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        behaviour = Behaviour.Look;
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        switch(behaviour)
        {
            case Behaviour.Look:
                GainStamina(staminaGainAmount * Time.deltaTime);
                GainHealth(healthGainAmount * Time.deltaTime);
                if(OnRangeEnter(7f))
                {
                    transform.LookAt(target);
                    behaviour = Behaviour.Attack;
                }
                break;
            case Behaviour.Attack:
                // moves towards the target.
                transform.position = Vector3.MoveTowards(transform.position, target.position, characterSpeed * Time.deltaTime);
                if (!IsWithinDistanceOfTarget(target, 7f))
                {
                    transform.LookAt(startPosition);
                    // if the enemies get far enough away from the player, it forgets the player
                    target = null;
                    // then it goes back to looking for a new target.
                    behaviour = Behaviour.Look;
                }
                break;
            case Behaviour.Flee:
                transform.position = Vector3.MoveTowards(transform.position, startPosition, characterSpeed * Time.deltaTime);
                if(!IsWithinDistanceOfTarget(target, 7f))
                {
                    transform.LookAt(startPosition);
                    // if the enemies get far enough away from the player, it forgets the player
                    target = null;
                    // then it goes back to looking for a new target.
                    behaviour = Behaviour.Look;
                }
                break;
            default:
                Debug.LogErrorFormat("Enemy {0} is behaving incorrectly", id);
                Debug.Break();
                break;
        }
    }

    private bool IsWithinDistanceOfTarget(Transform target, float distance)
    {
        if(Vector3.Distance(transform.position, this.target.position) <= distance)
        {
            return true;
        }
        return false;
    }

    private bool OnRangeEnter(float radius)
    {
        // create a sphere collider
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider hit in hitColliders)
        {
            // if any points of the collider hit the player add the players transform as the target
            if (hit && hit.gameObject.name == "Player")
            {
                target = hit.gameObject.transform;
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (behaviour == Behaviour.Attack && UseStamina(100f))
                other.GetComponent<Player>().TakeDamage(10f);
            behaviour = Behaviour.Flee;
        }
    }

}
