using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    
    public Transform target;
    public NavMeshAgent enemy;
 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        enemy.SetDestination(target.position);
        transform.LookAt(target.position);

    }


}
