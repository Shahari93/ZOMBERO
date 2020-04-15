using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    private static float currentTimer;
    [SerializeField] FloatingJoystick floatingJoystick = null;
    [SerializeField] SwitchWeaponsButton weaponButton = null;

    private void Awake()
    {
        currentTimer = timer;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        PlayerShoot();
    }

    private void PlayerShoot()
    {
        if (floatingJoystick.Vertical == 0 && floatingJoystick.Horizontal == 0)
        {
            GameObject bullet = BulletPool.singleton.Get("PlayerBullet");
            if (currentTimer<=0)
            {
                if (bullet != null && weaponButton.rangeGO.activeInHierarchy) // check the state of the weapon switch button. if active, player shoot. if not player stop shooting and use sword
                {
                    bullet.transform.position = this.transform.position;
                    bullet.transform.eulerAngles = this.transform.parent.eulerAngles; // takes to rotation angle of the parent object
                    bullet.SetActive(true);
                    currentTimer = timer;
                }
                if (GameManager.Singleton.Enemies.Count <= 0 || !weaponButton.rangeGO.activeInHierarchy) // stop shooting if there are no enemies on screen
                {
                    bullet.SetActive(false);
                }
            }
        }
    }
}
