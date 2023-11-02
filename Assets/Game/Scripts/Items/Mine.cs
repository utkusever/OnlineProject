using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Item
{
    protected override void UseItem()
    {
        Destroy(this.gameObject, 0.25f);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(value);
            UseItem();
        }
    }
}
