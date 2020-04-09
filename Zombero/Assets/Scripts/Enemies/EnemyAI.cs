using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public float speed;
    public int attackSpeed;
    public int attackDamage;

    public virtual void Attack()
    {

    }
}
