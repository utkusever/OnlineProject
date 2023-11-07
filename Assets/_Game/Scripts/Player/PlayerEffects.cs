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
    public void PlayEffectServerRpc(string itemTypeToSpawn, ServerRpcParams serverRpcParams = default)
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
            var goNetwork = go.GetComponent<NetworkObject>();
            goNetwork.Spawn();
            if (itemTypeToSpawn == "HomingRocket")
            {
                var clientId = serverRpcParams.Receive.SenderClientId;
                if (NetworkManager.ConnectedClients.ContainsKey(clientId))
                {
                    var client = NetworkManager.ConnectedClients[clientId];
                    go.transform.SetParent(client.PlayerObject.transform);
                    HomingClientRpc(clientId);
                    print(clientId);
                }
                // foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
                // {
                //     print(client.ClientId + "-" + clientId);
                //     if (client.ClientId == clientId)
                //     {
                //         print(client.ClientId);
                //         print(client.PlayerObject.GetComponent<PlayerController>());
                //         go.GetComponent<HomingMissile>().Init(client.PlayerObject.GetComponent<PlayerController>(), 20);
                //         break;
                //     }
                // }
            }


            if (itemTypeToSpawn != "HomingRocket")
            {
                Destroy(go, go.main.duration);
                StartCoroutine(DespawnTimer(go.main.duration, goNetwork));
            }
        }
    }

    [ClientRpc]
    private void HomingClientRpc(ulong clientId)
    {
        var client = NetworkManager.ConnectedClients[clientId];
        GetComponentInChildren<HomingMissile>().Init(client.PlayerObject.GetComponent<PlayerController>(), 20);
    }

    private IEnumerator DespawnTimer(float time, NetworkObject networkObjectToDespawn)
    {
        yield return new WaitForSeconds(time);
        networkObjectToDespawn.Despawn();
    }
}