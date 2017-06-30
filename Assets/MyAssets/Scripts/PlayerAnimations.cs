using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

    Animator animator;
    PlayerMovement movement;
    PlayerCombat combat;

    bool running;
    bool aiming;

    float vert, hor, run;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        combat = GetComponent<PlayerCombat>();
       
    }
    
    void Update()
    {
        
        vert = Input.GetAxis("VerticalLeft");
        hor = Input.GetAxis("HorizontalLeft");

        running = movement.running;
        aiming = combat.aiming;

        animator.SetFloat("Walking", vert);
        Running();
        DisableAnimatorWhenAiming();

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

    void DisableAnimatorWhenAiming()
    {
        if (aiming)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
    }

    

    

}
