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
        healthText.text = current.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
    if(collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDamageDealt(15);
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
}
