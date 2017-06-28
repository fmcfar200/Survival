using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour {

    //camera variables
    private Camera cam;
    private Transform cameraTrans;
    private float normalFOV, aimingFOV;
    
    //aiming
    public bool aiming;
    private float aim;
    private float fire;

    private const string aimString = "Aim";
    private const string fireString = "Fire";
    private const string vRightString = "VerticalRight";
    private const string hRightString = "HorizontalRight";


    public Transform gun;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;

    private int clip;
    private int ammo;
    private int maxClip;
    private int maxAmmo;

    //player
    public Transform playerSpine;
    private Quaternion normalSpinRotation = new Quaternion(0, 0, 0,0);

    // UI
    public Text ammoText;

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

        maxClip = 12;
        maxAmmo = 48;

        clip = maxClip;
        ammo = maxAmmo;


    }

    void Update()
    {
        aim = Input.GetAxis(aimString);
        fire = Input.GetAxis(fireString);

        if (aim == 0)
        {
            aiming = false;
        }
        else
        {
            aiming = true;

        }
        ammoText.text = clip.ToString() + "/" + ammo.ToString();

        if (Input.GetKeyDown("joystick button 2"))
        {
            if (clip < maxClip && ammo > 0)
            {
                Reload();
            }
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
                ResetSpine();
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

        if (fire == 1 && Time.time > nextFire && clip > 0)
        {
            nextFire = Time.time + fireRate;
            Fire(hit, ray);
            fire = 0;
        }
       

        float aimVertRight = Input.GetAxis(vRightString);
        float aimHorRight = Input.GetAxis(hRightString);

        
        playerSpine.Rotate(-Vector3.right * aimVertRight * 20.0f * Time.deltaTime);
        playerSpine.Rotate(Vector3.forward * aimHorRight * 20.0f * Time.deltaTime);


    }

    void Fire(RaycastHit target, Ray ray)
    {
        if (Physics.Raycast(ray, out target))
        {
            if (target.collider.gameObject.tag == "Enemy")
            {
                GameObject hitTarget = target.collider.gameObject;
                Destroy(hitTarget);
            }
        }

        clip--;
    }

    void ResetSpine()
    {
        playerSpine.rotation = normalSpinRotation;
    }

    void Reload()
    {
        int bulletsNeeded = maxClip - clip;

        if (ammo >= bulletsNeeded)
        {
            clip += bulletsNeeded;
            ammo -= bulletsNeeded;
        }
        else
        {
            clip += ammo;
            ammo -= ammo;
        }
    }
}
