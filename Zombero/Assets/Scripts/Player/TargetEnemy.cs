using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetEnemy : MonoBehaviour
{
    private void Update()
    {
        ShowTargetedEnemy();    
    }

    private void ShowTargetedEnemy()
    {
        
        Enemy enemy = FindObjectsOfType<Enemy>().OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();
        if(enemy!=null)
        {
        }
    }
}
