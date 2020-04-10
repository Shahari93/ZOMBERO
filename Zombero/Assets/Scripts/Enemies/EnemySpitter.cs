using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : EnemyAI
{
    [SerializeField] Transform player = null;
    [SerializeField] GameObject bullet = null;
    [SerializeField] GameObject bulletPoint = null;
    [SerializeField] private float timer = 0f;
    private bool isLooking = true;
    private bool isBulletFired = false;

    private void Awake()
    {
        bullet.transform.eulerAngles = new Vector3(90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
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
            this.transform.LookAt(player.transform);
            yield return new WaitForSeconds(timer);
            isLooking = false;
            timer = 3f;
        }
        yield return new WaitForSeconds(timer);
        isLooking = true;
    }
}
