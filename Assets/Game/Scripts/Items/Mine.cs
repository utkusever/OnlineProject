using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        Debug.Log("used mine");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(value);
        }
        Destroy(this.gameObject, 0.25f);
       // base.OnTriggerEnter(other);
    }
}
