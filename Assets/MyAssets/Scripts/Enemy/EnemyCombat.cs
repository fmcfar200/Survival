using UnityEngine;
using System.Collections;

public class EnemyCombat : MonoBehaviour {

    Transform enemyTransform;
    GameObject player;
    EnemyMovement movement;
    float playerDistance;

    public bool attacking = false;
    float attackRate = 3.0f;
    float nextAttack = 0.0f;

    float damage = 35f;

    void Start()
    {
        enemyTransform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
        movement = GetComponent<EnemyMovement>();
    }


    void FixedUpdate()
    {
        CheckDistance();

        if (attacking)
        {
            movement.walking = false;
            Attack();
        }
        else
        {
            movement.walking = true;
        }
    }

    void CheckDistance()
    {
        if (player != null)
        {
            playerDistance = movement.distance;

            if (playerDistance <= 1.25f)
            {
                movement.walking = false;
                attacking = true;
            }
            else
            {
                
                attacking = false;
            }
        }
        else
        {
            playerDistance = 20.0f;
            attacking = false;
        }
    }

    void Attack()
    {
        if (Time.time > nextAttack && playerDistance <= 1.25)
        {
            nextAttack = Time.time + attackRate;
            player.GetComponent<Health>().TakeDamage(damage);
            attacking = false;
        }
    }

}
