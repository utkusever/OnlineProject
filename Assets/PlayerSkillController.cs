using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // DmgBooster
        {
            if (playerInventory.HasItem(ItemType.DamageBooster))
            {
                //playerInventory.RemoveItem(ItemType.DamageBooster);
                playerInventory.UseItem(ItemType.DamageBooster);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)) //Health
        {
            if (playerInventory.HasItem(ItemType.HealthPotion))
            {

                // playerInventory.RemoveItem(ItemType.HealthPotion);
                playerInventory.UseItem(ItemType.HealthPotion);
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) //Homing 
        {
            if (playerInventory.HasItem(ItemType.HomingRocket))
            {
                // playerInventory.RemoveItem(ItemType.HomingRocket);
                playerInventory.UseItem(ItemType.HomingRocket);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Normal Shot
        {

        }
    }
}
