using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    private static float currentTimer;
    [SerializeField] FloatingJoystick floatingJoystick = null;
    [SerializeField] SwitchWeaponsButton weaponButton = null;
    [SerializeField] AudioSource bulletAudioSource = null;
    RaycastHit hit;
    int layerMask = 1 << 8;
    private void Awake()
    {
        currentTimer = timer;
    }

    private void FixedUpdate()
    {
        currentTimer -= Time.deltaTime;
        PlayerShoot();
    }

    private void PlayerShoot()
    {
        
        if (floatingJoystick.Vertical == 0 && floatingJoystick.Horizontal == 0 && Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity,layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            GameObject bullet = BulletPool.singleton.Get("PlayerBullet");
            if (currentTimer<=0)
            {
                if (bullet != null && weaponButton.rangeGO.activeInHierarchy) // check the state of the weapon switch button. if active, player shoot. if not player stop shooting and use sword
                {
                    bullet.transform.position = this.transform.position;
                    bullet.transform.eulerAngles = this.transform.parent.eulerAngles; // takes to rotation angle of the parent object
                    bulletAudioSource.Play();
                    bullet.SetActive(true);
                    currentTimer = timer;
                }
                if (GameManager.Singleton.Enemies.Count <= 0 || !weaponButton.rangeGO.activeInHierarchy) // stop shooting if there are no enemies on screen
                {
                    bullet.SetActive(false);
                    bulletAudioSource.Stop();
                }
            }
        }
    }
}
