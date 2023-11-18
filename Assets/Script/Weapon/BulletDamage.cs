using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletDamage : MonoBehaviour
{
    public TrailRenderer trail;

    public float destroyAfterSeconds;

    public float damage = 50f;

    public HitMarker hitIndicator;

    EnemyHealth enemy;


    private void Awake()
    {
        Destroy(gameObject, destroyAfterSeconds);
        trail = GetComponent<TrailRenderer>();

    }

    private void Start()
    {
        hitIndicator = FindObjectOfType<HitMarker>();
        StartCoroutine(Trail());
        //trail.startWidth = 0.02f;
        //trail.endWidth = 0.01f;
        //trail.time = 0.2f;
        //trail.material = new Material(Shader.Find("Unlit/Color"));
        //trail.material.color = Color.yellow;
    }


    private void Update()
    {
        //trail.transform.position = transform.position;

    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            hitIndicator.ShowHitMarker();
            Destroy(gameObject);
        }

        

    }

    //private void EnableImage()
    //{
    //    if (enemyHit)
    //    {
    //        Debug.LogWarning("co");
    //        hitEnemy.enabled = true;
    //        StartCoroutine(DisableHitIndicator());
    //    }
    //}

    private IEnumerator Trail()
    {
        trail.emitting = true;
        yield return new WaitForSeconds(destroyAfterSeconds);
    }

    //private IEnumerator DisableHitIndicator()
    //{
    //    enemyHit = false;
    //    yield return new WaitForSeconds(1f);
    //    hitEnemy.enabled = false;
    //}
   
}
