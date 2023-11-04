using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override void UseItem(PlayerInventory playerInventory)
    {
        Debug.Log("used health pot");
        if (effect != null)
        {
            var particle = Instantiate(effect, playerInventory.transform.position, Quaternion.identity);
            particle.Play();
        }

        if (playerInventory.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(-value);
        }
    }
}