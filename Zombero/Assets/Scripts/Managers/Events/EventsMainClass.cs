using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMainClass : MonoBehaviour
{
    public static Action weaponSwitch;
    public static Action openDoor;

    public void OnWeaponSwitch()
    {
        weaponSwitch?.Invoke();
    }

    public void OpenLevelDoor()
    {
        openDoor?.Invoke();
        Debug.Log("Door Is Open");
    }
}