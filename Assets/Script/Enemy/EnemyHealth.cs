using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health ;
    [SerializeField]
    GameManager manager ;

    [SerializeField]
    Enemy enemy;

    public void TakeDamage(float dmg)
    {
        health -= dmg;  
        if (health <= 0)
        {
            DestroyEnemy();
        }

    }

    public void DestroyEnemy()
    {
        StartCoroutine(enemy.Death());
        manager.points++;
    }


}
