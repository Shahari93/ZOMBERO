using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private void Awake()
    {
        GameObject door = GameObject.FindGameObjectWithTag("door");
    }
    private void Update()
    {
        GameManager.Singleton.OpenDoors(this.gameObject);
    }
}
