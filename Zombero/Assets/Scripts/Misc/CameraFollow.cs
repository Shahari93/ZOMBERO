using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _player = null;
    [SerializeField] float _yOffset = 10f;
    [SerializeField] float _zOffset = 5f; 
    Vector3 _cameraPos;

    void LateUpdate()
    {
        _cameraPos.x = _player.transform.position.x;
        _cameraPos.y = _player.transform.position.y + _yOffset;
        _cameraPos.z = _player.transform.position.z + _zOffset;
        transform.position = _cameraPos;
    }
}
