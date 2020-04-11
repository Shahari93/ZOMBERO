using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    PlayerMovement player;
    EnemySpitter enemySpitter;
    Rigidbody bulletRB;
    private Vector3 moveDir;
    private Vector3 playerPos;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement>();
        enemySpitter = FindObjectOfType<EnemySpitter>();
        playerPos = player.transform.position;
        moveDir = (playerPos - transform.position).normalized * enemySpitter.attackSpeed;
        bulletRB.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z);
    }
}
