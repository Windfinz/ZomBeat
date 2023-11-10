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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        enemy.SetDestination(target.position);
        transform.LookAt(target.position);

        if(enemy.remainingDistance <= enemy.stoppingDistance)
        {
            if(!enemy.hasPath || enemy.velocity.sqrMagnitude == 0f)
            {
                Debug.LogWarning("Co");
                anim.SetTrigger("attack1");
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

    


}
