using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Kamikaze : Item
{
    [SerializeField] float radius;

    public override void UseItem(PlayerInventory playerInventory)
    {
        if (!IsClient)
        {
            return;
        }

        if (effectPrefab != null)
        {
            playerInventory.GetComponent<PlayerEffects>().PlayEffectServerRpc(this.itemType.ToString());
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