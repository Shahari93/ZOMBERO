using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] FloatingJoystick floatingJoystick = null;
    [SerializeField] SwitchWeaponsButton weaponButton;
    private void Update()
    {
        if(floatingJoystick.Vertical==0 && floatingJoystick.Horizontal==0)
        {
            GameObject b = BulletPool.singleton.Get("PlayerBullet");
            if(Random.Range(0,101)<5)
            {
                if(b!=null&& weaponButton.rangeGO.activeInHierarchy) // check the state of the weapon switch button. if active, player shoot. if not player stop shooting and use sword
                {
                    b.transform.position = this.transform.position;
                    b.transform.eulerAngles = this.transform.parent.eulerAngles; // takes to rotation angle of the parent object
                    b.SetActive(true);
                }

               else if(!weaponButton.rangeGO.activeInHierarchy)
                {
                    b.SetActive(false);
                }

            }
        }
    }
}
