using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerEffects : NetworkBehaviour
{
    [SerializeField] ParticleSystem effect;
    public ParticleSystem Effect => effect;
    [SerializeField] private ParticleSystem healEffectPrefab;
    [SerializeField] private ParticleSystem kamikazeEffectPrefab;
    

    [ServerRpc(RequireOwnership = false)]
    public void PlayEffectServerRpc(string itemTypeToSpawn)
    {
        var position = this.transform.position;
        var go = itemTypeToSpawn switch
        {
            "Kamikaze" => Instantiate(kamikazeEffectPrefab, position, Quaternion.identity),
            "HealthPotion" => Instantiate(healEffectPrefab, position, Quaternion.identity),
            _ => null
        };

        if (go != null)
        {
            var goNetwork = go.GetComponent<NetworkObject>();
            goNetwork.Spawn();
            Destroy(go, go.main.duration);
            StartCoroutine(DespawnTimer(go.main.duration, goNetwork));
        }
    }

    private IEnumerator DespawnTimer(float time, NetworkObject networkObjectToDespawn)
    {
        yield return new WaitForSeconds(time);
        networkObjectToDespawn.Despawn();
    }
}