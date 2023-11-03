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
                particle.Play();
            }
            damageable.ApplyDamage(value);
        }
        Destroy(this.gameObject, 0.25f);
    }
}
