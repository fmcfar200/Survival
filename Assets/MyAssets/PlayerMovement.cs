using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;  //player object
    //Animator playerAnimator;
    Transform playerTransform;  //transform 

    private float runSpeed; //run speed

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
        }
    }

    void Start()
    {
        runSpeed = 1.0f;

        

    }

    void Update()
    {
        hLeft = Input.GetAxis(hLeftString);
        vLeft = Input.GetAxis(vLeftString);

        hRight = Input.GetAxis(hRightString);
        vRight = Input.GetAxis(vRightString);

    }

    void FixedUpdate()
    {
       
        playerTransform.Translate(Vector3.forward * runSpeed * vLeft * Time.deltaTime); //forward and backwards movement depending on axis float
        playerTransform.Translate(Vector3.right * runSpeed * hLeft * Time.deltaTime); // strathe movement depending on axis float
        playerTransform.Rotate(Vector3.up * vRight *20.0f * Time.deltaTime);
    }
}
