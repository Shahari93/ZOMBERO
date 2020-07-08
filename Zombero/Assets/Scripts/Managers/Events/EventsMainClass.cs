using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMainClass : MonoBehaviour
{
    public static Action weaponSwitch;
    public static Action activateTimer;
    public static Action<Sprite> allEnemiesAreDead;

    public void OnWeaponSwitch()
    {
        weaponSwitch?.Invoke();
    }
    public void OnActiveTimer()
    {
        activateTimer?.Invoke();
    }
}