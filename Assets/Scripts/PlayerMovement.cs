using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;

    public void Movement(float characterSpeed)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rigidBody.velocity = Vector2.zero;
        Vector3 impulse = new Vector3(h, 0, v).normalized * characterSpeed;
        rigidBody.AddRelativeForce(impulse, ForceMode.Impulse);
    }
}
