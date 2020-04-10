using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
    static int _health = 500; 
    static private int current = 500;
    [SerializeField] Image _healthBar = null;
    [SerializeField] Text healthText = null;

    private void Awake()
    {
        current = _health;
    }

    private void OnCollisionEnter(Collision collision)
    {
    if(collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(FlashObject(this.gameObject.GetComponent<MeshRenderer>(), Color.red, Color.red, 1f, .5f));
            PlayerDamageDealt(Random.Range(3,16));
        } 
    }

    public void PlayerDamageDealt(int _howMuchDamage) // can be used for the player and npc
    {
             float fillAmount = (float)current / (float)_health;
            current = current - _howMuchDamage;
            _healthBar.fillAmount = fillAmount;
            healthText.text = current.ToString();
            if(current<=0)
            {
                current = 0;
                healthText.text = current.ToString();
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
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}