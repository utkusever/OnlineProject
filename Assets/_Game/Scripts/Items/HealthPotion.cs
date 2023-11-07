using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HealthPotion : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        if (effectPrefab != null)
        {
            playerInventory.GetComponent<PlayerEffects>().PlayEffectServerRpc(this.itemType.ToString());
        }

        if (playerInventory.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(-value);
        }
    }
}