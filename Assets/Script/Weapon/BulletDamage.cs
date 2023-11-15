using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public TrailRenderer trail;

    public float destroyAfterSeconds;

    public float damage = 50f;

    EnemyHealth enemy;

    private void Awake()
    {
        Destroy(gameObject, destroyAfterSeconds);
        trail = GetComponent<TrailRenderer>();

    }

    private void Start()
    {
        StartCoroutine(Trail());
        trail.startWidth = 0.02f;
        trail.endWidth = 0.01f;
        trail.time = 0.2f;
        trail.material = new Material(Shader.Find("Unlit/Color"));
        trail.material.color = Color.yellow;
    }


    private void Update()
    {
        trail.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private IEnumerator Trail()
    {
        trail.emitting = true;
        yield return new WaitForSeconds(destroyAfterSeconds);
    }
   
}
