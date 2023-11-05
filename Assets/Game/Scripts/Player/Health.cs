using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : NetworkBehaviour, IDamageable
{
    public NetworkVariable<int>
        healthPoint = new NetworkVariable<int>(readPerm: NetworkVariableReadPermission.Everyone);

    [SerializeField] HealthBar healthBar;
    private int maxHealth = 100;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsServer)
        {
            return;
        }

        healthPoint.Value = 100;
    }

    public void ApplyDamage(int value)
    {
        AddHealthServerRpc(value);
        if (healthPoint.Value >= maxHealth) healthPoint.Value = maxHealth;
        if (IsDead())
        {
            this.gameObject.SetActive(false);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void AddHealthServerRpc(int value)
    {
        healthPoint.Value -= value;
    }

    public Transform GetTransform()
    {
        return this.transform;
    }


    public bool IsDead()
    {
        return healthPoint.Value <= 0;
    }
}