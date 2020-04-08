using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : EnemyAI
{
    PlayerMovement pm = null;
    [SerializeField] private float timer = 0f;
    private bool isLooking = true;
    void Awake()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        Attack();
        Debug.Log(timer);
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
            timer = 3f;
        }
        yield return new WaitForSeconds(timer);
        isLooking = true;
    }
}
