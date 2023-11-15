using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health ;
    
    public GameManager manager ;

    
    public Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        manager = FindObjectOfType<GameManager>();
    }

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
