using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    void Start()
    {
        items.Add(new Item("Gun", 0, "Standard Gun", Item.ItemType.Weapon));
        items.Add(new Item("Herb", 1, "Herb", Item.ItemType.Consumable));
    }
}
