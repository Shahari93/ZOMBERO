using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : EnemyAI
{
    GameObject bulletClone;
    [SerializeField] Transform player = null;
    [SerializeField] GameObject bullet = null;
    [SerializeField] Transform bulletPoint = null;
    [SerializeField] AudioSource bulletAudio = null;
    private bool isLooking = true;
    private bool isFired = false;

    private void Start()
    {
        bullet.transform.eulerAngles = new Vector3(90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }

    private void Update()
    {
        StartCoroutine(Spit());
    }
    private IEnumerator Spit()
    {
        if (isLooking)
        {
            this.transform.LookAt(player.transform);
            yield return new WaitForSeconds(3f);
            if(!isFired)
            {
                bulletClone = Instantiate(bullet, bulletPoint.position, bullet.transform.rotation);
                bulletAudio.Play();
                isFired = true;
            }
            Destroy(bulletClone,20);
            isLooking = false;
        }
        yield return new WaitForSeconds(3f);
        isFired = false;
        isLooking = true;
    }
}