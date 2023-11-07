using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float destroyAfterSeconds;

    public float damage = 50f;

    EnemyHealth enemy;

    private void Awake()
    {
        Destroy(gameObject, destroyAfterSeconds);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }


   
}
