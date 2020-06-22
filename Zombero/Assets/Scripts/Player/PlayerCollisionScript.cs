using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           playerScript.healthBarScript.PlayerDamageDealt(Random.Range(3, 16));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HandCollider"))
        {
            playerScript.healthBarScript.PlayerDamageDealt(Random.Range(5, 11));
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerScript.healthBarScript.PlayerDamageDealt(Random.Range(5, 11));
            Destroy(other.gameObject);
        }
    }
}
