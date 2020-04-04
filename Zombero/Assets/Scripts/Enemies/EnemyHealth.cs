using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyHealth : Enemy
{
    public event Action<float> OnHealthPctChanged = delegate { };
    EnemyFlash enemyFlash = null;
    private void Awake()
    {
        enemyFlash = FindObjectOfType<EnemyFlash>();
        currentHealth = health;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)health;
        OnHealthPctChanged(currentHealthPct);
    }

    void OnTriggerEnter(Collider other) // dealing with getting hit from stuff
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            ModifyHealth(-5);
            other.gameObject.SetActive(false);
            StartCoroutine(enemyFlash.FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.red, 1f, .5f));
            RemoveWhenHealthLow();
        }

        if (other.gameObject.CompareTag("Sword"))
        {
            ModifyHealth(-15);
            StartCoroutine(enemyFlash.FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.red, 1f, .5f));
            RemoveWhenHealthLow();
        }
    }
}