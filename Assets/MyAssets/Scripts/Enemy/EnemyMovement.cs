using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;

    float walkSpeed = 1.0f;
    public float distance;

    bool playerFound;
    public bool chasing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

       
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;

    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 5.0f)
        {
            playerFound = true;
        }
        else
        {
            playerFound = false;
        }
    }

    void FixedUpdate()
    {

        if (playerFound)
        {
            agent.destination = player.transform.position;
            chasing = true;

        }
        else
        {
            agent.destination = transform.position;
            chasing = false;
        }

        if (chasing == false)
        {
            agent.Stop();
        }
        else
        {
            agent.Resume();
        }
    }

 
}
