using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    
    public Transform target;
    public NavMeshAgent enemy;

    public Animator anim;

    private bool isDeath = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        
        if(!isDeath)
        {
            enemy.SetDestination(target.position);
            transform.LookAt(target.position);

        }

        if(enemy.remainingDistance <= enemy.stoppingDistance)
        {
            if(!enemy.hasPath || enemy.velocity.sqrMagnitude == 0f)
            {
                StartCoroutine(Attack());
            }
            else
            {
                anim.SetBool("stop", false);
            }
           
        }
        else
        {
            anim.SetBool("attack", true);
        }


    }

    public IEnumerator Attack()
    {
        enemy.speed = 0f;
        anim.SetTrigger("attack1");
        yield return new WaitForSeconds(2f);
        enemy.speed = 5f;

    }

    public IEnumerator Death()
    {
        isDeath = true;
        enemy.speed = 0f;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);


    }


}
