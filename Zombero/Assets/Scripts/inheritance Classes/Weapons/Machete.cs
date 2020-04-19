using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the methods in this script will be called from the weapon switch class
/// </summary>
public class Machete : MonoBehaviour, IFindEnemies
{
    Animator _macheteAnimator;
    [SerializeField] AudioSource macheteAudio = null;
    private void Start()
    {
        _macheteAnimator = gameObject.GetComponent<Animator>();
        macheteAudio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        FindEnemies();
        GameManager.Singleton.AllEnemiesAreDead(this.gameObject); // uses the game manager method to stop the machete animation when there are no enemies on screen.

    }

    public void FindEnemies()
    {
        float disToClosestEnemy = Mathf.Infinity;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy"); // create an array of all the gameobjects with the Enemy tag in the scene
        GameObject closestEnemy = null; // Empty GameObject for keeping the closest enemy from the array
        foreach (GameObject enemy in allEnemies) // looping on every enemy in that array
        {
            float disToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            if (disToEnemy < disToClosestEnemy)
            {
                disToClosestEnemy = disToEnemy;
                closestEnemy = enemy;
                if (disToEnemy < 3)
                {
                    _macheteAnimator.SetBool("isEnemyClose", true);
                    macheteAudio.Play();
                    Machete.FindObjectOfType<Machete>().GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else if (disToEnemy>=3)
                {
                    _macheteAnimator.SetBool("isEnemyClose", false);
                    Machete.FindObjectOfType<Machete>().GetComponent<MeshRenderer>().material.color = Color.blue;
                    macheteAudio.Stop();
                }
            }
        }
    }
}
