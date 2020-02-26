using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatingJoystick floatingJoystick = null;
    [SerializeField] Rigidbody rb = null;
    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 50f;
    private Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the Rigidbody component from the gameobject
        rb.freezeRotation = true; // stop all rotation on the axis
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove() // basic movement method
    {
        float moveHorizontal = floatingJoystick.Horizontal;
        float moveVertical = floatingJoystick.Vertical;
        dir = new Vector3(moveHorizontal, 0.0f, moveVertical); // That's the direction the player is moving
        if (dir != Vector3.zero) // if the dir is not equle to Vector3 (0,0,0) [Means that there is a movement] then..
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime); // to a rotation to the direction the player is facing
        }
        rb.MovePosition(transform.position + movementSpeed * Time.deltaTime * dir);// player movement.
    }
}