using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        Debug.Log("used health pot");
        if (effectPrefab != null)
        {
            effectInstance = Instantiate(effectPrefab, playerInventory.transform.position, Quaternion.identity);
            base.PlayParticleClientRpc();
            Destroy(effectInstance.gameObject,effectInstance.time);
        }

        if (playerInventory.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(-value);
        }
    }
}