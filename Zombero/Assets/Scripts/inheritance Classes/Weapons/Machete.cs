using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machete : MonoBehaviour
{
    [SerializeField] GameObject _machete;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!_machete.activeInHierarchy)
        {
            Debug.LogError("Sda");
        }
        
    }
}
