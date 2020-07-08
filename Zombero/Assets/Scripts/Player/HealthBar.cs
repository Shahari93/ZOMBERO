using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour 
{
    [SerializeField] PlayerScript playerScript = null;

    static int _health = 500;
    static private int current = 500;

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
        _howMuchDamage = 5;
        float fillAmount = (float)current / (float)_health;
        current = current - _howMuchDamage;
        playerScript._healthBar.fillAmount = fillAmount;
        playerScript.healthText.text = current.ToString();
        if (current<=0)
            {
                current = 0;
            playerScript.healthText.text = current.ToString();
            }

        if (playerScript.immunedTime <= 0)
        {

            current -= _howMuchDamage;

            if (current > 0)
            {
                playerScript.immunedTime = playerScript.immuned;
                playerScript.playerRender.enabled = false;
                playerScript.gunRender.enabled = false;
                playerScript.magazineRender.enabled = false;
                playerScript.blinkTime = playerScript.blink;
                playerScript.gettingHitAudioSource.Play();
            }
        }
    }

    private void Immune()
    {
        if (playerScript.immunedTime > 0)
        {
            playerScript.immunedTime -= Time.deltaTime;
            playerScript.blinkTime -= Time.deltaTime;
            if (playerScript.blinkTime <= 0)
            {
                playerScript.playerRender.enabled = !playerScript.playerRender.enabled;
                playerScript.gunRender.enabled = !playerScript.gunRender.enabled;
                playerScript.magazineRender.enabled = !playerScript.magazineRender.enabled;
                playerScript.blinkTime = playerScript.blink;
            }
            if (playerScript.immunedTime <= 0)
            {
                playerScript.playerRender.enabled = true;
                playerScript.gunRender.enabled = true;
                playerScript.magazineRender.enabled = true;
            }
        }
    }
}