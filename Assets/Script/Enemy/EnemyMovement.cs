using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController controller;
    public Transform target;

    [SerializeField]
    float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction = direction.normalized;
        Vector3 velocity = direction * speed;
        controller.Move(velocity * Time.deltaTime);


    }


}
