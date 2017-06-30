using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;

    float walkSpeed = 1.0f;
    public float distance;

    bool playerFound;
    public bool walking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerFound = true;
        }
        else
        {
            playerFound = false;
        }
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;

    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        if (playerFound)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            agent.destination = player.transform.position;
            walking = true;

        }
        else
        {
            distance = 20.0f;
            agent.destination = transform.position;
            walking = false;
        }

        if (walking == false)
        {
            agent.Stop();
        }
        else
        {
            agent.Resume();
        }
    }
}
