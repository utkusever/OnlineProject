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
            // if (effectPrefab != null)
            // {
            //     effectInstance = Instantiate(effectPrefab, this.transform.position + new Vector3(0, 1, 0),
            //         Quaternion.identity);
            //     base.PlayParticleClientRpc();
            //     Destroy(effectInstance.gameObject, effectInstance.time);
            // }

            damageable.ApplyDamage(value);
        }

        base.DestroyServerRpc();
    }
}