using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : Enemy
{
    public Transform child;

    public event Action<float> OnHealthPctChanged = delegate { };
    [SerializeField] Canvas redArrow = null;
    private void Awake()
    {
        currentHealth = health;
        redArrow.GetComponentInChildren<Image>().enabled = false;
    }
    void Update()
    {
        child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
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
            RemoveWhenHealthLow();
        }

        if (other.gameObject.CompareTag("Sword"))
        {
            ModifyHealth(-15);
            RemoveWhenHealthLow();
        }
    }
}