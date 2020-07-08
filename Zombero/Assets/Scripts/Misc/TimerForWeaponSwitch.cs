using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerForWeaponSwitch : MonoBehaviour
{
    public bool isTimerActive = false;
    public float timer;

    private void Awake()
    {
        EventsMainClass.weaponSwitch += ActivateTimer;
    }

    public void Timer() // method for a timer to count backwards from X to 0
    {
        if (isTimerActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                isTimerActive = false;
                this.gameObject.GetComponent<Button>().enabled = true; // sets the button to true
                this.gameObject.GetComponent<Image>().color = Color.blue; // set the button color to blue
            }
        }
    }

   public void ActivateTimer()
   {
       isTimerActive = true;
       this.gameObject.GetComponent<Button>().enabled = false;
       Timer();
   }
}
