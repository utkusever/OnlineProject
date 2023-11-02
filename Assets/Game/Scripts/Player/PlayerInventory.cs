using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;
using UnityEngine;

public class PlayerInventory : Subject
{
    private InGameUI inGameUI;
    private Dictionary<ItemType, int> inventory = new();
    private Dictionary<ItemType, Item> inventory2 = new();
    private void Start()
    {
        if (inGameUI == null)
        {
            inGameUI = UIManager.Instance.GetCanvas(CanvasTypes.InGame) as InGameUI;
        }
    }
    public void AddItem(ItemType itemToAdd, Item item)
    {
        if (!inventory.ContainsKey(itemToAdd))
        {
            inventory.Add(itemToAdd, 1);
            inventory2.Add(itemToAdd, item);
            inGameUI.UpdateInventoryUI(itemToAdd, inventory[itemToAdd]);
        }
        else
        {
            inventory[itemToAdd]++;
            inGameUI.UpdateInventoryUI(itemToAdd, inventory[itemToAdd]);
        }


        print("item type " + itemToAdd + " count: " + inventory[itemToAdd]);
    }
    public void RemoveItem(ItemType itemToRemove)
    {
        if (inventory.ContainsKey(itemToRemove))
        {
            inventory[itemToRemove]--;
            inGameUI.UpdateInventoryUI(itemToRemove, inventory[itemToRemove]);
            CheckHasEnoughItem(itemToRemove);
        }
    }

    private void CheckHasEnoughItem(ItemType itemToRemove)
    {
        if (inventory[itemToRemove] <= 0)
        {
            inventory.Remove(itemToRemove);
            inventory2.Remove(itemToRemove);
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
    public void UseItem(ItemType itemToUse)
    {
        var item = inventory2[itemToUse];
        item.UseItem(this);
        RemoveItem(itemToUse);
    }
}
