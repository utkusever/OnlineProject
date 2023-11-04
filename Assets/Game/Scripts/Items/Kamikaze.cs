using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Item
{
    [SerializeField] float radius;

    public override void UseItem(PlayerInventory playerInventory)
    {
        if (effect != null)
        {
            var particle = Instantiate(effect, playerInventory.transform.position, Quaternion.identity);
            particle.Play();
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