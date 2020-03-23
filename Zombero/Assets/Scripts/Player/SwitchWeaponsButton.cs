using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeaponsButton : Machete
{
    public GameObject rangeGO = null, meleeGO = null, swordGO = null;
    [SerializeField]float timer;
    [SerializeField]bool isTimerActive = false;
    //[SerializeField] Machete machete = null;
    private void Awake()
    {
        swordGO.SetActive(false);
    }

    private void Update()
    {
        TimerForButton();
    }

    void Timer() // method for a timer to count backwards from X to 0
    {
        if (isTimerActive)
        {
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                timer = 0;
                isTimerActive = false;
                this.gameObject.GetComponent<Button>().enabled = true; // sets the button to true
                this.gameObject.GetComponent<Image>().color = Color.blue; // set the button color to blue
            }
        }
    }

    public void OnWeaponSwitchButtonPressed()
    {
        if(rangeGO.activeInHierarchy)
        {
            rangeGO.SetActive(false);
            meleeGO.SetActive(true);
            swordGO.SetActive(true);
            MacheteLogic();
            SetColor();
        }
        else if(meleeGO.activeInHierarchy)
        {
            rangeGO.SetActive(true);
            meleeGO.SetActive(false);
            swordGO.SetActive(false);
            SetColor();
        }
    }

    void TimerForButton()
    {
        if(rangeGO.activeInHierarchy)
        {
            ActivateTimer();
        }

        else if (meleeGO.activeInHierarchy)
        {
            ActivateTimer();
        }
    }
    void ActivateTimer()
    {
        isTimerActive = true;
        this.gameObject.GetComponent<Button>().enabled = false;
        Timer();
    }

    void SetColor()
    {
        this.gameObject.GetComponent<Image>().color = Color.gray;
        timer = 5f;
    }
}