using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [Header("Scripts references")]
    [SerializeField] internal HealthBar healthBarScript = null;
    [SerializeField] internal PlayerCollisionScript playerCollisionScript = null;

    [Header("Serialization settings")]
    [SerializeField] internal float blink = 0f;
    [SerializeField] internal float immuned = 0;
    [SerializeField] internal float blinkTime = 0.1f;
    [SerializeField] internal float immunedTime = 0f;

    [Header("Components serialization")]
    [SerializeField] internal Renderer playerRender = null;
    [SerializeField] internal Renderer gunRender = null;
    [SerializeField] internal Renderer magazineRender = null;
    [SerializeField] internal Image _healthBar = null;
    [SerializeField] internal Text healthText = null;
    [SerializeField] internal AudioSource gettingHitAudioSource = null;
}
