using UnityEngine;
using System.Collections;

public class Footstep : MonoBehaviour {

    public delegate void MovementEvent();
    public static event MovementEvent onStep;

    bool once = false;
    float timerReset = 0.12f;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            if (!once)
            {
                onStep();
                once = true;
                Invoke("Reset", timerReset);
            }
        }
    }

    void Reset()
    {
        once = false;
    }
}
