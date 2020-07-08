using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private Animator enemyAnimator = null;
    [SerializeField] private float stoppingDis = 1.5f;
    public float speed;
    public float attackSpeed;

    private void Update()
    {
        Attack();        
    }

    private void Attack()
    {
        this.transform.LookAt(player.transform);
        if(Vector3.Distance(this.transform.position, player.transform.position)>stoppingDis)
        { 
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position,speed * Time.deltaTime);
            enemyAnimator.SetBool("isClose", false);
        }
        if (Vector3.Distance(this.transform.position,player.transform.position)<=stoppingDis)
        {
            enemyAnimator.SetBool("isClose", true);
        }
    }
}
