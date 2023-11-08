using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health ;
    [SerializeField]
    GameManager manager ;

    public void TakeDamage(float dmg)
    {
        health -= dmg;  
        if (health <= 0)
        {
            Debug.LogWarning("bi danh");
            DestroyEnemy();
        }

    }

    public void DestroyEnemy()
    {
        manager.points++;
        Destroy(gameObject);
    }


}
