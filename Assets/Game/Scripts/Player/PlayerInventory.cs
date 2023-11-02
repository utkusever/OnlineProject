using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Subject
{
    private Dictionary<ItemType, int> inventory = new();
    private void Start()
    {

    }
    public void AddItem(ItemType itemToAdd)
    {
        if (!inventory.ContainsKey(itemToAdd))
        {
            inventory.Add(itemToAdd, 1);
        }
        else
            inventory[itemToAdd]++;

        print("item type " + itemToAdd + " count: " + inventory[itemToAdd]);
    }
    public void RemoveItem(ItemType itemToRemove)
    {
        if (inventory.ContainsKey(itemToRemove))
        {
            inventory[itemToRemove]--;
        }
    }
    public bool HasItem(ItemType item)
    {
        if (inventory.ContainsKey(item))
        {
            return true;
        }
        return false;
    }
}
