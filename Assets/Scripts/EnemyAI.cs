using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] float turnSpeed = 5f;


    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;


    bool isAggro = false;

    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<EnemyHealth>().IsDead())
        {
            enabled = false;
            nMA.enabled = false;
            Destroy(gameObject, 3);
        }

        distanceToTarget = Vector3.Distance(playerTarget.position, transform.position);

        if (isAggro)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isAggro = true;
        }

    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= nMA.stoppingDistance)
        {
            ChasePlayer();
        }

        else if (distanceToTarget <= nMA.stoppingDistance)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("isMoving", true);
        nMA.SetDestination(playerTarget.transform.position);
    }


    private void AttackPlayer()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void onDamageTaken()
    {
        isAggro = true;
    }
}
