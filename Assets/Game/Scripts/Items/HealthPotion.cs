using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        Debug.Log("used health pot");
        if (playerInventory.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(-value);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(this.gameObject, 0.25f);

        // if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        // {
        //     damageable.ApplyDamage(-value);
        // }
    }
}
