using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class Item : NetworkBehaviour
{
    public ItemType itemType;
    public float value;
    public ParticleSystem effect;

    public virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    public abstract void UseItem(PlayerInventory playerInventory);

    protected virtual void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerInventory>().AddItem(itemType, this);
        DestroyServerRpc();
    }

    [ServerRpc]
    protected void DestroyServerRpc()
    {
        Destroy(this.gameObject);
    }

    [ClientRpc]
    protected void PlayParticleClientRpc()
    {
        effect.Play();
    } 
}