using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
    static int _health = 500; 
    static private int current = 500;
    public float blink;
    public float immuned;
    private float blinkTime = 0.1f;
    private float immunedTime;
    [SerializeField]  Renderer playerRender = null;
    [SerializeField] Image _healthBar = null;
    [SerializeField] Text healthText = null;

    private void Awake()
    {
        current = _health;
    }

    #region collision
    private void OnCollisionEnter(Collision collision)
    {
    if(collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDamageDealt(Random.Range(3,16));
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("HandCollider"))
        {
            PlayerDamageDealt(Random.Range(5, 11));
        }
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            PlayerDamageDealt(Random.Range(5, 11));
            Destroy(other.gameObject);
        }
    }
    #endregion 

    private void Update()
    {
        Immune();
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

        if (immunedTime <= 0)
        {

            current -= _howMuchDamage;

            if (current <= 0)
            {

            }
            else
            {
                immunedTime = immuned;
                playerRender.enabled = false;
                blinkTime = blink;
            }
        }
    }

    private void Immune()
    {
        if (immunedTime > 0)
        {

            immunedTime -= Time.deltaTime;

            blinkTime -= Time.deltaTime;

            if (blinkTime <= 0)
            {
                playerRender.enabled = !playerRender.enabled;
                blinkTime = blink;
            }
            if (immunedTime <= 0)
            {
                playerRender.enabled = true;
            }
        }
    }
}