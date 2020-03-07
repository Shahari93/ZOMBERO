using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour 
{
    public int _health = 100;

    public void PlayerDamageDealt(int _howMuchDamage) // can be used for the player and npc
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _health = _health - _howMuchDamage;
        }
    }
}
