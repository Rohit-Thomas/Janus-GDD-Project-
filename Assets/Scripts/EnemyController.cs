using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 5f;
    public float eatRadius = 3f;
    public float number = 1f;
    NavMeshAgent agent;
    Transform target;
    Transform baitStand;
    public bool inCombat { get; private set; }
    public bool isEating { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        if (number == 1)
        {
            baitStand = PlayerManager.instance.baitStand.transform;
        }
        else if (number == 2)
        {
            baitStand = PlayerManager.instance.baitStand2.transform;
        }
        else if (number ==3)
        {
            baitStand = PlayerManager.instance.baitStand3.transform;
        }
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.stoppingDistance = attackRadius;
        float distance = Vector3.Distance(target.position, transform.position);
        float baitDistance = Vector3.Distance(baitStand.position, transform.position);

        if (baitDistance <= (lookRadius * 2) && CheckChicken())
        {
            agent.SetDestination(baitStand.position);
            if (baitDistance <= eatRadius)
            {
                //add attack here
                //agent.isStopped = true;
                agent.velocity = Vector3.zero;
                FaceBait();
                isEating = true;
                
            }
            else
            {             
                isEating = false;
            }
        }
        else if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <= attackRadius)
            {
                //add attack here
                //agent.isStopped = true;
                agent.velocity = Vector3.zero;
                agent.isStopped = true;
                inCombat = true;
                FaceTarget();
            }
            else
            {
                agent.isStopped = false;
                inCombat = false;
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void FaceBait()
    {
        Vector3 direction = (baitStand.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    bool CheckChicken()
    {
        if (number == 1 && PlayerManager.instance.chickenOnStand.activeSelf)
        {
            return true;
        }
        else if (number == 2 && PlayerManager.instance.chickenOnStand2.activeSelf)
        {
            return true;
        }
        else if (number == 3 && PlayerManager.instance.chickenOnStand3.activeSelf)
        {
            return true;
        }
        else
            return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, eatRadius);
    }

}
