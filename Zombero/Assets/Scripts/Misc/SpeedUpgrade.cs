using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour
{
    [SerializeField] PlayerMovement pm = null;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm._playerMovement += 2;
            Debug.Log("Player");
            StartCoroutine(DestroyMyself());
        }
    }

    IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
    }
}
