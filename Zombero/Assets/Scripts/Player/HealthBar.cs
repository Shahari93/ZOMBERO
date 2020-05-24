using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
    public float blink;
    public float immuned;
    private float blinkTime = 0.1f;
    private float immunedTime;
    static int _health = 500; 
    static private int current = 500;
    [SerializeField]  Renderer playerRender = null;
    [SerializeField]  Renderer gunRender = null;
    [SerializeField]  Renderer magazineRender = null;
    [SerializeField] Image _healthBar = null;
    [SerializeField] Text healthText = null;
    [SerializeField] AudioSource gettingHitAudioSource = null;

    private void Awake()
    {
        current = _health;
    } 

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

            if (current > 0)
            {
                immunedTime = immuned;
                playerRender.enabled = false;
                gunRender.enabled = false;
                magazineRender.enabled = false;
                blinkTime = blink;
                gettingHitAudioSource.Play();
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
                gunRender.enabled = !gunRender.enabled;
                magazineRender.enabled = !magazineRender.enabled;
                blinkTime = blink;
            }
            if (immunedTime <= 0)
            {
                playerRender.enabled = true;
                gunRender.enabled = true;
                magazineRender.enabled = true;
            }
        }
    }
}