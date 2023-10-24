using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animation anim;


    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    private void Update()
    {
        anim.Play("Run");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.Play("Death");
        Debug.LogWarning("Danh");
    }

}
