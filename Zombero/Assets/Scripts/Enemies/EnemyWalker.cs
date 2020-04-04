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
        //StartCoroutine(AttackLogic());
    }
    /*IEnumerator AttackLogic()
    {
        
    }*/
}
