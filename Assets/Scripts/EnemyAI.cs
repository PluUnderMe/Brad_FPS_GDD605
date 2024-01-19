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
    void Start() // gets the nav mesh agent and lets the script know what the tag player is 
    {
        nMA = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<EnemyHealth>().IsDead()) //disables and destroys the enemy once they are dead
        {
            enabled = false;
            nMA.enabled = false;
            Destroy(gameObject, 3);
        }

        distanceToTarget = Vector3.Distance(playerTarget.position, transform.position); //sets the aggro distance towards the player

        if (isAggro)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isAggro = true;
        }

    }

    private void EngageTarget() //changes the enemy to chase or attack the player depending on distance between them
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

    private void ChasePlayer() //sets the animtion to moving when chaing the player
    {
        GetComponent<Animator>().SetBool("isMoving", true);
        nMA.SetDestination(playerTarget.transform.position);
    }


    private void AttackPlayer() //sets teh animation to attack when attacking the player
    {
        GetComponent<Animator>().SetBool("isAttacking", true);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget() //makes the enemy face towards the player
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void onDamageTaken() //lets the enemy become aggro is attacked
    {
        isAggro = true;
    }
}
