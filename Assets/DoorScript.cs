using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public bool locked = false;

    void Update()
    {

    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("joystick button 3"))
            {
                //open door
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        Transform doorTrans = this.transform;
        doorTrans.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }
    
}
