using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Item : NetworkBehaviour
{
    public ItemType itemType;
    public int value;
    public ParticleSystem effectPrefab;

    public abstract void UseItem(PlayerInventory playerInventory);

    protected virtual void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerInventory>().AddItem(itemType, this);
        DestroyServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    protected void DestroyServerRpc()
    {
        this.GetComponent<NetworkObject>().Despawn();
        Destroy(this.gameObject);
    }
    
}