using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

    Animator animator;
    EnemyMovement movement;
    EnemyCombat combat;
    Health health;
    NavMeshAgent agent;

    bool walking;
    bool attacking;
    bool dead;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<EnemyMovement>();
        combat = GetComponent<EnemyCombat>();
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        attacking = combat.attacking;
        walking = movement.walking;
        dead = health.dead;
       
        animator.SetBool("Walking", walking);
        animator.SetBool("Attacking", attacking);
        animator.SetBool("Death", dead);
       

    }

}
