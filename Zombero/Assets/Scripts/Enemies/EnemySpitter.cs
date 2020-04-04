using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : EnemyAI
{
    PlayerMovement pm = null;
    [SerializeField] private float timer = 0f;
    private bool isTimerOn = false;
    private bool isLooking = true;
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
        StartCoroutine(Spit());
    }

    private IEnumerator Spit()
    {
        if(isLooking)
        {
            this.transform.LookAt(pm.gameObject.transform);
            yield return new WaitForSeconds(timer);
            isLooking = false;
            Debug.Log("Attack");
            timer = 3;
        }
        yield return new WaitForSeconds(timer);
        isLooking = true;
    }

    void TimerForEnemy()
    {
        if(isTimerOn)
        {
            timer -= Time.deltaTime;
            
            if(timer<=0)
            {
                timer = 0;
                isTimerOn = false; 
                Debug.Log("Timer is off");
            }
        }
    }
}
