using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _bullet = null;
    GameObject _bulletPrefab;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _bulletPrefab = Instantiate(_bullet, this.transform.position, Quaternion.identity);
        }

        Destroy(_bulletPrefab,3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if(other.gameObject.tag=="Finish")
        {
            Destroy(other.gameObject);
        }
    }
}
