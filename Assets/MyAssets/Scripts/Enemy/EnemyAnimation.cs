using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

    Animator animator;
    EnemyMovement movement;
    EnemyCombat combat;

    NavMeshAgent agent;

    bool walking;
    bool attacking;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<EnemyMovement>();
        combat = GetComponent<EnemyCombat>();
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        attacking = combat.attacking;
        walking = movement.walking;
       
       
        animator.SetBool("Walking", walking);
        animator.SetBool("Attacking", attacking);

       

    }

}
