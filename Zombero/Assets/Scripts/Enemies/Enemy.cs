using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int currentHealth;
    private void Awake()
    {
        GameManager.Singleton.AddEnemies(this.gameObject); // here we add all the enemies into a list.
    }

    public void RemoveWhenHealthLow()
    {
        if(currentHealth<=0)
        {
            GameManager.Singleton.RemoveEnemies(this.gameObject); // when the enemy gets hit by the bullet we remove it from the list
        }
    }
}