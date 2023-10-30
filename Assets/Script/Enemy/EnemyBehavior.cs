using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animation anim;


    private void Awake()
    {
        

    }

    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    private void Update()
    {
        anim.Play("Run");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.Play("Attack1");
        Debug.LogWarning("Danh");
    }

}
