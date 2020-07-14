using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMainClass : MonoBehaviour
{
    public static Action weaponSwitch;

    public void OnWeaponSwitch()
    {
        weaponSwitch?.Invoke();
    }
}