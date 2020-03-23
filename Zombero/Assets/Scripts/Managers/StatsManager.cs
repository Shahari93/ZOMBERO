using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public float _playerMovement;
    public float _rotationSpeed;

    private void Update()
    {
        Debug.Log(_playerMovement);
    }
}
