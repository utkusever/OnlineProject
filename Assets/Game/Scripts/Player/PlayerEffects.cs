using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerEffects : NetworkBehaviour
{
    [SerializeField] ParticleSystem effect;
    public ParticleSystem Effect => effect;
    [SerializeField] private ParticleSystem healEffectPrefab;


    [ServerRpc(RequireOwnership = false)]
    public void PlayHealEffectServerRpc()
    {
        print("play heal effect");
        // if (!IsOwner)
        // {
        //     return;
        // }
        var go = Instantiate(healEffectPrefab, this.transform.position, Quaternion.identity);
        var goNetwork = go.GetComponent<NetworkObject>();
        goNetwork.Spawn(true);
        go.Play();
        //goNetwork.Despawn();
    }
}