using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    private void Awake()
    {
        GameManager.Singleton.AddEnemies(this.gameObject); // here we add all the enemies into a list.
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 5;
            other.gameObject.SetActive(false);
            RemoveWhenHealthLow();
        }

        if (other.gameObject.CompareTag("Sword"))
        {
            health -= 15;
            RemoveWhenHealthLow();
        }
    }
    void RemoveWhenHealthLow()
    {
        if (health <= 0)
        {
            GameManager.Singleton.RemoveEnemies(this.gameObject); // when the enemy gets hit by the bullet we remove it from the list
        }
    }
}
