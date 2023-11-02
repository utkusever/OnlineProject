using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        Debug.Log("used homing");
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(this.gameObject, 0.2f);

    }
}
