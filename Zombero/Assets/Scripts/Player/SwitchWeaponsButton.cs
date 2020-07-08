using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeaponsButton : Machete
{
    public GameObject rangeGO = null, meleeGO = null, swordGO = null; 
    [SerializeField] AudioSource buttonAudioSource = null;
    [SerializeField] TimerForWeaponSwitch timer = null;

    private void Awake()
    {
        EventsMainClass.weaponSwitch += OnWeaponSwitchButtonPressed;
        swordGO.SetActive(false);
    }

    private void Update()
    {
        TimerForButton();
    }

    public void OnWeaponSwitchButtonPressed()
    {
        if(rangeGO.activeInHierarchy)
        {
            rangeGO.SetActive(false);
            meleeGO.SetActive(true);
            swordGO.SetActive(true);
            FindObjectOfType<PlayerMovement>()._playerMovement -= 2;
            SetColor();
            buttonAudioSource.Play();
        }
        else if(meleeGO.activeInHierarchy)
        {
            rangeGO.SetActive(true);
            meleeGO.SetActive(false);
            swordGO.SetActive(false);
            FindObjectOfType<PlayerMovement>()._playerMovement += 2;
            SetColor();
            buttonAudioSource.Play();
        }
    }

    void TimerForButton()
    {
        if(rangeGO.activeInHierarchy)
        {
           timer.ActivateTimer();
        }

        else if (meleeGO.activeInHierarchy)
        {
            timer.ActivateTimer();
        }
    }


    void SetColor()
    {
        this.gameObject.GetComponent<Image>().color = Color.gray;
        timer.timer = 5f;
    }
}