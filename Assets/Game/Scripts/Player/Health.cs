using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour, IDamageable
{
    [SerializeField] float health;
    [SerializeField] HealthBar healthBar;
    private float maxHealth = 100;


    public void ApplyDamage(float value)
    {
        ApplyDamageClientRpc(value);
    }

    [ClientRpc]
    private void ApplyDamageClientRpc(float value)
    {
        health -= value;
        if (health >= maxHealth) health = maxHealth;
        healthBar.UpdateBar(new NetworkVariable<float>(health));
        if (IsDead())
        {
            this.gameObject.SetActive(false);
        }
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}