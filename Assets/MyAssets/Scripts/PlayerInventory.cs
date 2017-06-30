using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

    public GameObject slots;

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
