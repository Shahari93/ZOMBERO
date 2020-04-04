﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager 
{

    private static GameManager instance;
    private List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> Enemies { get { return enemies; } }

    public static GameManager Singleton // create instance of game manger
    { 
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public void AddEnemies (GameObject enemy) // every script can use this method to add enemies to this list
    { 
        enemies.Add(enemy);
    }

    public void RemoveEnemies (GameObject enemy) // every script can use this method to remove enemies to this list
    {
        int index = enemies.IndexOf(enemy);
        enemies.RemoveAt(index);
        enemy.SetActive(false);
    }

    public void OpenDoors(GameObject door)
    {
        if(enemies.Count<=0)
        {
            door.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public void AllEnemiesAreDead(GameObject sword)//for cancling the machete animation
    {
        if (enemies.Count <= 0)
        {
            sword.gameObject.GetComponent<Animator>().SetBool("isEnemyClose", false);
        }
    }
}
