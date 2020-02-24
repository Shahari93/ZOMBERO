using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DataForCharacters
{

    [SerializeField] FloatingJoystick FloatingJoystick = null;
    [SerializeField] Rigidbody rb = null;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        /*DamageDealt(5);  */   // gets the method from the DataForCharacters class
        /*PowerStrength(5);*/   // gets the method from the DataForCharacters class
        PlayerMovement();
    }

    void PlayerMovement() // basic movement method
    {
        //Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        Vector3 direction = Vector3.forward * FloatingJoystick.Vertical + Vector3.right * FloatingJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
