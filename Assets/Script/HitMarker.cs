using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMarker : MonoBehaviour
{
    public float time;
    public Image image;

    public void ShowHitMarker()
    {
        StopCoroutine(Wait(time));
        image.enabled = true;
        StartCoroutine(Wait(time));

    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        image.enabled = false;
    }

}
