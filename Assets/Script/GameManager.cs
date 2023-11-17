using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int points;

    public GameObject hitIndicator;
    public BulletDamage bullet;


    //private void Update()
    //{
    //    if (bullet.enemyHit)
    //    {
    //        StartCoroutine(Wait());
    //    }
    //    else 
    //    {
    //        StopCoroutine(Wait());
    //    }
    //}

    //private IEnumerator Wait()
    //{
    //    Debug.Log("kich hoat");

    //    hitIndicator.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //    hitIndicator.SetActive(false);

    //}

}
