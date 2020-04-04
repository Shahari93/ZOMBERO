using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : EnemyAI
{
    PlayerMovement pm = null;
    void Awake()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        this.transform.LookAt(pm.gameObject.transform);
    }
}
