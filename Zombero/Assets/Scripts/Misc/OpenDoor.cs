using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private void Awake()
    {
        GameObject door = GameObject.FindGameObjectWithTag("door"); // add the door as a game object
    }
    private void Update()
    {
        GameManager.Singleton.OpenDoors(this.gameObject); // uses the game manager method to open the door.
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Zombero 1");
        }
    }
}
