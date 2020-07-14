using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Usage of "IsKinematic" rigidbody:
/// In general all moving gameobject in Unity needs to be with rigidbody component.
/// At the start of the game Unity physics engine check all static gameobject (non-rigidbody) once and they are not checked again
/// When we move a static gameobject, all other static gameobject needs to be rechecked for accuracy. (cost alot of performence).
/// That's where kinematic rigidbody enters. we can move the game object using its transform but for unity it still a static gameobject.
/// The kinematic game object effects other gameobject but it won't be effected by physics
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField] Vector3 _speed = new Vector3(0,0,0);
    [SerializeField] GameObject bPrefab = null;

    private void FixedUpdate()
    {
        bPrefab.transform.Translate(_speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false); // setting the bullet to be inactive when they leave the screen. when the became invisable they go back to the object pool
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
