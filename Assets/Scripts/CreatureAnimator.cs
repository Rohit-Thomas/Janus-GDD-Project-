using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureAnimator : MonoBehaviour
{

    const float movementAnimationSmoothTime = .1f;
    Animator animator;
    NavMeshAgent agent;
    protected EnemyController combat;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<EnemyController>();
        animator.SetBool("inCombat", combat.inCombat);
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, movementAnimationSmoothTime, Time.deltaTime);
        animator.SetBool("inCombat", combat.inCombat);
        animator.SetBool("isEating", combat.isEating);
    }
}
