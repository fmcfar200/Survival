using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item
{

    public string itemName;
    public int itemID;
    public string itemDesc;
    public Sprite itemIcon;
    public GameObject itemModel;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Quest
    }

    public Item(string name, int id, string desc, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemType = type;
    }

    public Item()
    {

    }

}
