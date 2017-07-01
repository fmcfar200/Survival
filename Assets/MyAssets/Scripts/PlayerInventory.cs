using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    InventoryDatabase itemDatabase;

    public List<Item> items;
    public List<Item> playersItems = new List<Item>();
    public List<GameObject> itemSlotPrefabs = new List<GameObject>();


    int itemCount;
    int slotsAvailable = 8;
    
    void Start()
    {
        itemDatabase = GetComponent<InventoryDatabase>();
        items = itemDatabase.items;

        SetStartingItems();
    }

    void Update()
    {
        itemCount = playersItems.Count;
    }

    void SetStartingItems()
    {
        //adds items to inventory list
        for (int i = 0; i < 3; i++)
        {
            playersItems.Add(items[i]);
            itemCount++;

        }

        for (int i = 0; i < itemCount; i++)
        {
            GameObject slotItem = (GameObject)Instantiate(itemSlotPrefabs[i], this.transform);
        }  
        
    }
}
