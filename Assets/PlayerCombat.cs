using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    private Camera cam;
    private Transform cameraTrans;
    private float normalFOV, aimingFOV;
    
    public bool aiming;
    private float aim;
    private string aimString = "Aim";

    public Transform gun;
    
    void Awake()
    {
        cam = Camera.main;
        cameraTrans = cam.transform;
    }
    void Start()
    {
        aiming = false;
        normalFOV = 60.0f;
        aimingFOV = 30.0f;

    }

    void Update()
    {
        aim = Input.GetAxis(aimString);

        if (aim == 0)
        {
            aiming = false;
        }
        else
        {
            aiming = true;

        }

    }

    void FixedUpdate()
    {

        switch (aiming)
        {
            case true:
                cam.fieldOfView = aimingFOV;
                gun.transform.GetChild(0).gameObject.GetComponent<LineRenderer>().enabled = true;
                Aim();
                break;

            case false:
                cam.fieldOfView = normalFOV;
                gun.transform.GetChild(0).gameObject.GetComponent<LineRenderer>().enabled = false;

                break;
        }
    }

    void Aim()
    {
        RaycastHit hit;
        Ray ray = new Ray(gun.position, gun.forward);

        if (Physics.Raycast(ray,out hit))
        {
            print("Aiming at: " + hit.collider.name);
        }
    }
}
