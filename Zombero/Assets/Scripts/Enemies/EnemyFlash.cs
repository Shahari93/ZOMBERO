using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    public IEnumerator FlashObject(MeshRenderer toFlash, Color originalColor, Color flashColor, float flashTime, float flashSpeed)
    {
        float flashingFor = 0;
        var newColor = flashColor;
        while (flashingFor < flashTime)
        {
            toFlash.material.color = newColor;
            flashingFor += Time.deltaTime;
            yield return new WaitForSeconds(flashSpeed);
            flashingFor += flashSpeed;
            if (newColor == flashColor)
            {
                newColor = originalColor;
            }
            else
            {
                newColor = flashColor;
            }
        }
        if(gameObject!=null)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
