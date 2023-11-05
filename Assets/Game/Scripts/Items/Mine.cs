using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (!IsServer)
        {
            return;
        }

        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (effectPrefab != null)
            {
                other.GetComponent<PlayerEffects>().PlayEffectServerRpc(this.itemType.ToString());
            }

            damageable.ApplyDamage(value);
        }

        base.DestroyServerRpc();
    }
}