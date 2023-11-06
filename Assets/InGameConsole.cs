using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IngameDebugConsole;

public class InGameConsole : MonoBehaviour
{
    private static Generator generator;

    void Start()
    {
        generator = GameManager.Instance.GetGenerator();
        DebugLogConsole.AddCommand<ItemType, int>("create", "Creates items", CreateItems);
        DebugLogConsole.AddCommand("create_pot", "creates health potions", CreateHealthPots);
        DebugLogConsole.AddCommand("battlefield", "Fill the area with mines", BattleField);
        DebugLogConsole.AddCommand("hesoyam", "Fill the area with potions", Hesoyam);
        DebugLogConsole.AddCommand("create_5_cubes", "Fill the area with potions", Create5Cubes);
        
        // DebugLogConsole.AddCommand<string>("create", "Creates items",CreateItems);
        //DebugLogConsole.AddCommand( "destroy", "Destroys " + name, Destroy );
        // DebugLogConsole.AddCommand<string, GameObject>( "child", "Creates a new child object under " + name, AddChild );
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private static void CreateItems(ItemType itemType, int value)
    {
        generator.GenerateItem(itemType, value);
    }

    private static void CreateHealthPots()
    {
        generator.GenerateItem(ItemType.HealthPotion,1);
    }

    private static void BattleField()
    {
        generator.GenerateItem(ItemType.Mine, 25);
    }

    private static void Hesoyam()
    {
        generator.GenerateItem(ItemType.HealthPotion, 25);
    }
    private static void Create5Cubes()
    {
        generator.GenerateItem(ItemType.Mine, 5);
    }

    private GameObject AddChild(string name)
    {
        GameObject child = new GameObject(name);
        child.transform.SetParent(transform);

        return child;
    }
}