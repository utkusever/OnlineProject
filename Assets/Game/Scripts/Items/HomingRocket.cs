using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : Item
{
    [SerializeField] HomingMissile missile;

    public override void UseItem(PlayerInventory playerInventory)
    {
        var rocket = Instantiate(missile, playerInventory.transform.position, Quaternion.identity);
        rocket.Init(playerInventory.GetComponent<PlayerController>(), value);
        Debug.Log("used homing");
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(this.gameObject);
    }


}
