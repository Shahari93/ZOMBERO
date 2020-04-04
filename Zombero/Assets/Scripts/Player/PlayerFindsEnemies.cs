using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFindsEnemies : MonoBehaviour, IFindEnemies
{
    private Vector3 dir = new Vector3(0,0,0);

    void FixedUpdate()
    {
        FindEnemies();    
    }

    public void FindEnemies()
    {
        float disToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null; // no closestEnemy at the start of the game
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy"); // create an array of all the gameobjects with the Enemy tag in the scene
        foreach (GameObject enemy in allEnemies) // looping on every enemy in that array
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < disToClosestEnemy)
            {
                disToClosestEnemy = disToEnemy;
                closestEnemy = enemy;
                if (closestEnemy.transform.position.y >= 0.0f || closestEnemy.transform.position.y <= 1f) // only if the target highet is equle to this y value the player will shoot at him. if not the player will still target the enemy but WILL NOT shoot at him
                {
                    this.transform.LookAt(closestEnemy.transform);
                }
            }
        }
    }
}
