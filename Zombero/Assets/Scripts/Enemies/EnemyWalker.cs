using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : EnemyAI
{
    private void Update()
    {
        Attack();        
    }

    public override void Attack()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
    }
}
