using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataForCharacters : MonoBehaviour
{
    public float _movementSpeed;
    public int _damagePower;
    public int _health;

   public void DamageDealt(int _howMuchDamage) // can be used for the player and npc
    {
        _health = _health - _howMuchDamage;
    }

    public void PowerStrength(int _damage) // can be used for the player and npc
    {
        _damagePower = _damage + 5;
    }

}
