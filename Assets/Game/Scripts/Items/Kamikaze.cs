using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Item
{
    [SerializeField] float radius;

    public override void UseItem(PlayerInventory playerInventory)
    {
        if (effectPrefab != null)
        {
            effectInstance = Instantiate(effectPrefab, playerInventory.transform.position, Quaternion.identity);
            base.PlayParticleClientRpc();
            //Destroy(effectInstance.gameObject,effectInstance.time);
        }

        RaycastHit[] hits = Physics.SphereCastAll(playerInventory.transform.position, radius, Vector3.up, 0);
        foreach (var hit in hits)
        {
            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.ApplyDamage(value);
            }
        }
    }
}