using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the methods in this script will be called from the weapon switch class
/// </summary>
public class Machete : MonoBehaviour
{
    public void MacheteLogic()
    {
        FindObjectOfType<PlayerMovement>()._playerMovement -= 2;
        CloseEnemy();
    }
    public void NonMachete()
    {
        FindObjectOfType<PlayerMovement>()._playerMovement += 2;
    }

    void CloseEnemy()
    {
        float disToCloseEnemy = Mathf.Infinity;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy"); // create an array of all the gameobjects with the Enemy tag in the scene
        foreach (GameObject enemy in allEnemies) // looping on every enemy in that array
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < disToCloseEnemy)
            {
                Machete.FindObjectOfType<Machete>().GetComponent<MeshRenderer>().material.color= Color.red;
            }
        }
    }
}
