﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] FloatingJoystick floatingJoystick = null;
    [SerializeField] SwitchWeaponsButton weaponButton = null;
    private void Update()
    {
        if(floatingJoystick.Vertical==0 && floatingJoystick.Horizontal==0)
        {
            GameObject bullet = BulletPool.singleton.Get("PlayerBullet");
            if(Random.Range(0,101)<5)
            {
                if(bullet!=null&& weaponButton.rangeGO.activeInHierarchy) // check the state of the weapon switch button. if active, player shoot. if not player stop shooting and use sword
                {
                    bullet.transform.position = this.transform.position;
                    bullet.transform.eulerAngles = this.transform.parent.eulerAngles; // takes to rotation angle of the parent object
                    bullet.SetActive(true);
                }

               else if(!weaponButton.rangeGO.activeInHierarchy)
                {
                    bullet.SetActive(false);
                }

            }
        }
    }
}
