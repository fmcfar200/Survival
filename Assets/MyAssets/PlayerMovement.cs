using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;
    Animator playerAnimator;
    Transform playerTransform;

    private float runSpeed;
    private bool moving;

    private string verticalString = "Vertical";
    private string horizontalString = "Horizontal";
    private float hor;
    private float vert;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player!= null)
        {
            playerAnimator = player.GetComponent<Animator>();
            playerTransform = player.transform;
        }
    }

    void Start()
    {
        runSpeed = 1.0f;
        moving = false;

        

    }

    void Update()
    {
        hor = Input.GetAxis(horizontalString);
        vert = Input.GetAxis(verticalString);

        if (vert > 0)
        {
            playerAnimator.SetBool("Moving", true);
        }
        else
        {
            playerAnimator.SetBool("Moving", false);
        }
    }

    void FixedUpdate()
    {
        if (vert > 0 || vert < 0)
        {
            playerTransform.Translate(Vector3.forward * runSpeed * vert * Time.deltaTime);
            
        }
        else if (hor > 0 || hor < 0)
        {
            playerTransform.Translate(Vector3.right * runSpeed * hor * Time.deltaTime);

        }

    }
}
