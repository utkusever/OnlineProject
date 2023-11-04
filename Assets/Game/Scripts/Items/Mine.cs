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
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (effect != null)
            {
                var particle = Instantiate(effect, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                base.PlayParticleClientRpc();
                Destroy(particle.gameObject, particle.time);
            }

            damageable.ApplyDamage(value);
        }

        base.DestroyServerRpc();
    }
}