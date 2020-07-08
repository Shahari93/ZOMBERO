using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerScript.healthBarScript.PlayerDamageDealt(UnityEngine.Random.Range(5, 11));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandCollider"))
        {
            playerScript.healthBarScript.PlayerDamageDealt(UnityEngine.Random.Range(5, 11));
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerScript.healthBarScript.PlayerDamageDealt(UnityEngine.Random.Range(5, 11));
            Destroy(other.gameObject);
        }
    }
}