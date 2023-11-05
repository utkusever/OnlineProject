using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        if (effectPrefab != null)
        {
            Debug.Log("used health pot");
            playerInventory.GetComponent<PlayerEffects>().PlayEffectServerRpc(this.itemType.ToString());
        }

        if (playerInventory.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(-value);
        }
    }
}