using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;  //player object
    private PlayerCombat combatScript;
    //Animator playerAnimator;
    Transform playerTransform;  //transform 

    private float runSpeed; //run speed
    private float walkSpeed;
    private float currentSpeed;

    private bool running;

    //Input strings and floats
    private const string vLeftString = "VerticalLeft";
    private const string hLeftString = "HorizontalLeft";

    private const string vRightString = "VerticalRight";
    private const string hRightString = "HorizontalRight";

    private float hLeft;
    private float vLeft;
    private float hRight;
    private float vRight;



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player!= null)
        {
            //playerAnimator = player.GetComponent<Animator>();
            playerTransform = player.transform;
            combatScript = GetComponent<PlayerCombat>();
        }
    }

    void Start()
    {
        walkSpeed = 1.0f;
        runSpeed = 2.5f;
        currentSpeed = walkSpeed;
        running = false;
        

    }

    void Update()
    {
        hLeft = Input.GetAxis(hLeftString);
        vLeft = Input.GetAxis(vLeftString);

        hRight = Input.GetAxis(hRightString);
        vRight = Input.GetAxis(vRightString);

        if (Input.GetKey("joystick button 0"))
        {
            running = true;
        }
        else
        {
            running = false;
        }
        

        if (running)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

    }

    void FixedUpdate()
    {
        if (!combatScript.aiming)
        {
            playerTransform.Translate(Vector3.forward * currentSpeed * vLeft * Time.deltaTime); //forward and backwards movement depending on axis float
            playerTransform.Translate(Vector3.right * currentSpeed * hLeft * Time.deltaTime); // strathe movement depending on axis float
        }
        playerTransform.Rotate(Vector3.up * vRight *20.0f * Time.deltaTime);
    }
}
