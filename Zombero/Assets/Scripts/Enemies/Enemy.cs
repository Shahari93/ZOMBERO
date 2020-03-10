using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void Awake()
    {
        GameManager.Singleton.AddEnemies(this.gameObject); // here we add all the enemies into a list.
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            other.gameObject.SetActive(false);
            GameManager.Singleton.RemoveEnemies(this.gameObject); // when the enemy gets hit by the bullet we remove it from the list
        } 
    }
}
