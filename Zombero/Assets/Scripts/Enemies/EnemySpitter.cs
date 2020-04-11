using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : EnemyAI
{
    GameObject bulletClone;
    [SerializeField] Transform player = null;
    [SerializeField] GameObject bullet = null;
    [SerializeField] Transform bulletPoint = null;
    [SerializeField] private float timer = 3f;
    private bool isLooking = true;

    private void Start()
    {
        bullet.transform.eulerAngles = new Vector3(90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }

    private void Update()
    {
        StartCoroutine(Spit());
    }

    public override void Attack()
    {
    }
    private IEnumerator Spit()
    {
        if (isLooking)
        {
            this.transform.LookAt(player.transform);
            yield return new WaitForSeconds(timer);
            bulletClone = Instantiate(bullet, bulletPoint.position, bullet.transform.rotation);
            isLooking = false;
            timer = 3f;
            Destroy(bulletClone,5);
            yield return new WaitForSecondsRealtime(6);
        }
        yield return new WaitForSeconds(timer);
        isLooking = true;
    }
}