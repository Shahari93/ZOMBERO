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
            StartCoroutine(FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.green, 1f, .5f));
            RemoveWhenHealthLow();
        }

        if (other.gameObject.CompareTag("Sword"))
        {
            health -= 15;
            StartCoroutine(FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.green, 1f, .5f));
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

    IEnumerator FlashObject(MeshRenderer toFlash, Color originalColor, Color flashColor, float flashTime, float flashSpeed)
    {
        float flashingFor = 0;
        var newColor = flashColor;
        while (flashingFor < flashTime)
        {
            toFlash.material.color = newColor;
            flashingFor += Time.deltaTime;
            yield return new WaitForSeconds(flashSpeed);
            flashingFor += flashSpeed;
            if (newColor == flashColor)
            {
                newColor = originalColor;
            }
            else
            {
                newColor = flashColor;
            }
        }
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

}
