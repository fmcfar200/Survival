using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("Gun", 0, "Standard Handgun", Item.ItemType.Weapon));
        items.Add(new Item("Handgun Ammo", 1, "Ammo for handgun", Item.ItemType.Consumable));
        items.Add(new Item("Medkit", 2, "Increases health by 50", Item.ItemType.Consumable));
    }


}
