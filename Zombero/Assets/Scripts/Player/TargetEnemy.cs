﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TargetEnemy : MonoBehaviour
{

    Enemy lastTargetEnemy;

    private void Update()
    {
        ShowTargetedEnemy();    
    }

    private void ShowTargetedEnemy()
    {
        Enemy enemy = FindObjectsOfType<Enemy>().OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();
        if(enemy!=null)
        {
            EnableTarged(enemy);
        }
    }

     private void DisableTargeted(Enemy enemy)
    {
        if(enemy == null)
        {
            return;
        }
        enemy.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().enabled = false;

        //enemy.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private void EnableTarged(Enemy enemy)
    {
        DisableTargeted(lastTargetEnemy);
        enemy.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().enabled = true;
        //enemy.GetComponent<MeshRenderer>().material.color = Color.green;
        lastTargetEnemy = enemy;
    }
}
