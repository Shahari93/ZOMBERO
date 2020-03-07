using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBar
{

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDamageDealt(10);
    }
}
