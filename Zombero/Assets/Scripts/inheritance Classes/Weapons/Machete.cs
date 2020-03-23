using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// the methods in this script will be called from the weapon switch class
/// </summary>
public class Machete : MonoBehaviour
{
   public void MacheteLogic()
    {
        Debug.Log("sd");
        FindObjectOfType<PlayerMovement>()._playerMovement -= 2;
    }
}
