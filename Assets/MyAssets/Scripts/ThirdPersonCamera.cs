using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform cameraTransform;

    private Camera cam;

    private float dist = 2.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensX = 4.0f;
    private float sensY = 1.0f;

    void Start()
    {
        cameraTransform = transform;
        cam = Camera.main;

        
    }

    void Update()
    {
       
    }

    void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -dist);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cameraTransform.position = lookAt.position + rotation * direction;
        cameraTransform.LookAt(lookAt.position);
    }


}
