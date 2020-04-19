using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    [SerializeField] Sprite closedDoor = null;
    [SerializeField] Sprite openedDoor = null;
    [SerializeField] AudioSource openDoorAudio = null;

    private void Awake()
    {
        GameObject door = GameObject.FindGameObjectWithTag("door"); // add the door as a game object
        this.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor;
    }
    private void Update()
    {
        GameManager.Singleton.OpenDoors(this.gameObject); // uses the game manager method to open the door.
        StartCoroutine(OpenDoorCoroutine(openedDoor));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Zombero 1");
        }
    }
    IEnumerator OpenDoorCoroutine(Sprite newDoor)
    {
        if(GameManager.Singleton.isEnemiesLeft)
        {
            openDoorAudio.Play();
            yield return new WaitForSecondsRealtime(.5f);
            this.GetComponent<SpriteRenderer>().sprite = newDoor;
        }
    }
}
