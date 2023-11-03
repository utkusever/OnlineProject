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
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(this.gameObject, 0.2f);

        // if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        // {
        //     damageable.ApplyDamage(-value);
        // }
    }
}
