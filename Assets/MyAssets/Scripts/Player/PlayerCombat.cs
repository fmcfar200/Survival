using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    public delegate void ShotEvent();
    public delegate IEnumerator ReloadEvent();
    public static event ShotEvent onShoot;
    public static event ReloadEvent onReload;


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
    public GameObject pointPrefab;
    GameObject point;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public int clip;
    public int ammo;
    private int maxClip;
    private int maxAmmo;

    //player
    public Transform playerSpine;
    private Quaternion normalSpinRotation = new Quaternion(0, 0, 0,0);



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

        if (Input.GetKeyDown("joystick button 2"))
        {
            if (clip < maxClip && ammo > 0)
            {
                StartCoroutine(Reload());
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
                gun.transform.GetChild(1).gameObject.SetActive(true);

                Aim();


                break;

            case false:
                cam.fieldOfView = normalFOV;
                gun.transform.GetChild(0).gameObject.GetComponent<LineRenderer>().enabled = false;
                gun.transform.GetChild(1).gameObject.SetActive(false);
                if (point != null)
                {
                    Destroy(point);
                }
                ResetSpine();                
                break;
        }
    }

    void Aim()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);

        RaycastHit hit;
        Ray ray = new Ray(gun.position, gun.forward);

        if (Physics.Raycast(ray, out hit, 150.0f))
        {
            point = GameObject.FindGameObjectWithTag("Point");
            if ( point == null)
            {
                Instantiate(pointPrefab, hit.point, Quaternion.identity, gun);
            }
            else
            {
                point.transform.position = hit.point;
            }
        }

        if (fire == 1 && Time.time > nextFire && clip > 0)
        {
            nextFire = Time.time + fireRate;
            Fire(hit, ray);
            fire = 0;
        }
       

        float aimVertRight = Input.GetAxis(vRightString);
        float aimHorRight = Input.GetAxis(hRightString);

        //playerSpine.Rotate(-Vector3.right * aimVertRight * 20.0f * Time.deltaTime);
        playerSpine.Rotate(Vector3.forward * aimHorRight * 20.0f * Time.deltaTime);
        transform.Rotate(Vector3.up * aimVertRight * 20.0f * Time.deltaTime);
    }

    void Fire(RaycastHit target, Ray ray)
    {
        onShoot();
        if (Physics.Raycast(ray, out target))
        {
            if (target.collider.gameObject.tag == "Enemy")
            {
                GameObject hitTarget = target.collider.gameObject;
                Health targetHealth = hitTarget.GetComponent<Health>();
                targetHealth.TakeDamage(20.0f);
            }
            else if (target.collider.gameObject.tag == "EnemyHead")
            {
                GameObject hitTarget = target.transform.root.gameObject;
                Health targetHealth = hitTarget.GetComponent<Health>();
                targetHealth.TakeDamage(50.0f);
                if (targetHealth.currentHealth <= 0)
                {
                    Destroy(target.collider.gameObject);
                }
            }
        }

        clip--;
    }

    void ResetSpine()
    {
        playerSpine.rotation = normalSpinRotation;
    }

    IEnumerator Reload()
    {
        AudioManager aManager = GetComponent<AudioManager>();
        StartCoroutine(onReload());
        yield return new WaitForSeconds((aManager.gun1Sounds[1].length + aManager.gun1Sounds[2].length) + 0.1f);
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
