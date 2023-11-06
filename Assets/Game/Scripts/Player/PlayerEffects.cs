using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerEffects : NetworkBehaviour
{
    [SerializeField] ParticleSystem effect;
    public ParticleSystem Effect => effect;
    [SerializeField] private ParticleSystem healEffectPrefab;
    [SerializeField] private ParticleSystem kamikazeEffectPrefab;
    [SerializeField] private ParticleSystem mineEffectPrefab;
    [SerializeField] private ParticleSystem homingMissilePrefab;
    [SerializeField] private PlayerController playerController;
    

    [ServerRpc(RequireOwnership = false)]
    public void PlayEffectServerRpc(string itemTypeToSpawn)
    {
        var position = this.transform.position;
        var go = itemTypeToSpawn switch
        {
            "Kamikaze" => Instantiate(kamikazeEffectPrefab, position, Quaternion.identity),
            "HealthPotion" => Instantiate(healEffectPrefab, position, Quaternion.identity),
            "Mine" => Instantiate(mineEffectPrefab, position, Quaternion.identity),
            "HomingRocket" => Instantiate(homingMissilePrefab, position, Quaternion.identity),
            _ => null
        };


        // if (itemTypeToSpawn == "HomingRocket")
        // {
        //     go.GetComponent<HomingMissile>().Init(this.GetComponent<PlayerController>(), 20);
        //     var goNetwork = go.GetComponent<NetworkObject>();
        //     goNetwork.Spawn();
        // }

        if (go != null)
        {
            if (itemTypeToSpawn == "HomingRocket")
            {
                go.GetComponent<HomingMissile>().Init(playerController, 20);
            }

            var goNetwork = go.GetComponent<NetworkObject>();
            goNetwork.Spawn();
            if (itemTypeToSpawn != "HomingRocket")
            {
                Destroy(go, go.main.duration);
                StartCoroutine(DespawnTimer(go.main.duration, goNetwork));
            }
        }
    }

    private IEnumerator DespawnTimer(float time, NetworkObject networkObjectToDespawn)
    {
        yield return new WaitForSeconds(time);
        networkObjectToDespawn.Despawn();
    }
}