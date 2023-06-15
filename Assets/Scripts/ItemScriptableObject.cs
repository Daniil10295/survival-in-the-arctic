using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default, Food, Instrument, Weapon, Armor, Consumable };
public class ItemScriptableObject : ScriptableObject
{  
    public ItemType itemType;
    public GameObject itemPrefab;
    public string itemName;
    public string itemDescription;
    public int maxAmount;
    public int currentAmount;
}