using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : StatsManager
{
    [SerializeField] FloatingJoystick floatingJoystick = null;
    [SerializeField] Rigidbody rb = null;
    private Vector3 dir;

    void Start()
    {
        rb.freezeRotation = true; // stop all rotation on the axis
    }

    void FixedUpdate()
    {
        FindEnemies();
        PlayerMove();
    }

    void PlayerMove() // basic movement method
    {
        float moveHorizontal = floatingJoystick.Horizontal;
        float moveVertical = floatingJoystick.Vertical;
        dir = new Vector3(moveHorizontal, 0.0f, moveVertical); // That's the direction the player is moving
        if (dir != Vector3.zero) // if the dir is not equle to Vector3 (0,0,0) [Means that there is a movement] then..
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _rotationSpeed * Time.deltaTime); // to a rotation to the direction the player is facing
        }
        rb.MovePosition(transform.position + _playerMovement * Time.deltaTime * dir);// player movement.
    }

    public void FindEnemies()
    {
        float disToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null; // no closestEnemy at the start of the game
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy"); // create an array of all the gameobjects with the Enemy tag in the scene
        foreach (GameObject enemy in allEnemies) // looping on every enemy in that array
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < disToClosestEnemy)
            {
                disToClosestEnemy = disToEnemy;
                closestEnemy = enemy;
                if (closestEnemy.transform.position.y >= 0.0f || closestEnemy.transform.position.y <= 1f) // only if the target highet is equle to this y value the player will shoot at him. if not the player will still target the enemy but WILL NOT shoot at him
                {
                    this.transform.LookAt(closestEnemy.transform);
                }
            }
        }
    }
}