using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] GameObject _bullet = null;
    GameObject _bulletPrefab;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject b = BulletPool.singleton.Get("PlayerBullet");
            if(b!=null)
            {
                b.transform.position = this.transform.position;
                b.SetActive(true);
            }
        }

    }
}
