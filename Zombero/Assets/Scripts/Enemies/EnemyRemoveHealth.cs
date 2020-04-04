using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRemoveHealth : Enemy
{
    EnemyFlash _enemyFlash = null;
    private void Awake()
    {
        _enemyFlash = FindObjectOfType<EnemyFlash>();      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 5;
            other.gameObject.SetActive(false);
            StartCoroutine(_enemyFlash.FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.red, 1f, .5f));
            RemoveWhenHealthLow();
        }

        if (other.gameObject.CompareTag("Sword"))
        {
            health -= 15;
            StartCoroutine(_enemyFlash.FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.red, 1f, .5f));
            RemoveWhenHealthLow();
        }
    }
}
