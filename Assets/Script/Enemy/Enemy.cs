using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;

    public GameObject target;
    public NavMeshAgent enemy;
    public BoxCollider boxCollider;

    public Animator anim;

    public bool isDeath = false;
    private bool readyToAttack = true;

    public float damage = 5f;

    public float range;

    [SerializeField]
    private PlayerHealth player;

    private void Start()
    {
        AssignTarget();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerHealth>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void AssignTarget()
    {
        target = GameObject.Find("Player");
    }

    private void Update()
    {

        if (!isDeath)
        {
            enemy.SetDestination(target.transform.position);
            transform.LookAt(target.transform.position);

        }

        if (enemy.remainingDistance <= enemy.stoppingDistance)
        {
            if (!enemy.hasPath || enemy.velocity.sqrMagnitude == 0f)
            {
                if (readyToAttack)
                {
                    StartCoroutine(Attack());
                    StartCoroutine(WaitTimeToAttack());

                }

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

    public IEnumerator WaitTimeToAttack()
    {
        readyToAttack = false;
        yield return new WaitForSeconds(3f);
        readyToAttack = true;
    }

    public IEnumerator Attack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Player"))
            {
                enemy.speed = 0f;
                anim.SetTrigger("attack1");
                yield return new WaitForSeconds(1f);
                CheckCanAttack();
                yield return new WaitForSeconds(0.5f);
                enemy.speed = 5f;

            }
        }


    }

    private void CheckCanAttack()
    {
        if (enemy.remainingDistance <= enemy.stoppingDistance + 2f)
        {
            player.TakeDamage(damage);

        }
    }

    public IEnumerator Death()
    {
        isDeath = true;
        boxCollider.enabled = false;
        enemy.speed = 0f;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);


    }



}
