using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeaponsButton : MonoBehaviour
{
     public GameObject rangeGO = null, meleeGO = null, swordGO = null;
    private void Awake()
    {
        swordGO.SetActive(false);
    }

    public void OnWeaponSwitchButtonPressed()
    {
        if(rangeGO.activeInHierarchy)
        {
            rangeGO.SetActive(false);
            meleeGO.SetActive(true);
            swordGO.SetActive(true);
        }
        else if(meleeGO.activeInHierarchy)
        {
            rangeGO.SetActive(true);
            meleeGO.SetActive(false);
            swordGO.SetActive(false);
        }
    }
}
