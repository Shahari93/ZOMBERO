using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]public int health = 200;
    [HideInInspector]public int currentHealth;
    private void Awake()
    {
        GameManager.Singleton.AddEnemies(this.gameObject); // here we add all the enemies into a list.
    }

    public void RemoveWhenHealthLow()
    {
        if(currentHealth<=0)
        {
            //yield return new WaitForSeconds(2f); // When needed to add death animation I can do this here
            GameManager.Singleton.RemoveEnemies(this.gameObject); // when the enemy gets hit by the bullet we remove it from the list
        }
    }
}