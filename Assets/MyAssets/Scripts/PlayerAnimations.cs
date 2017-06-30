using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

    Animator animator;
    PlayerMovement movement;

    bool running;

    float vert, hor, run;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();

       
    }
    
    void Update()
    {
        
        vert = Input.GetAxis("VerticalLeft");
        hor = Input.GetAxis("HorizontalLeft");
        running = movement.running;

        animator.SetFloat("Walking", vert);
        Running();
    }

    void Running()
    {
        if (running == true)
        {
            run = 0.2f;
        }
        else
        {
            run = 0.0f;
        }

        animator.SetFloat("Running", run);
    }

}
