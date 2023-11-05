using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Generator : NetworkBehaviour
{
    [SerializeField] private Item healthPot;
    [SerializeField] private Item mine;
    [SerializeField] private Item homingRocket;
    [SerializeField] private Item kamikaze;
    [SerializeField] private float boundX;
    [SerializeField] private float boundZ;

    public void GenerateItem(ItemType itemToSpawn, int itemToSpawnCount)
    {
        if (!IsOwner)
        {
            return;
        }

        for (int i = 0; i < itemToSpawnCount; i++)
        {
            Item item = itemToSpawn switch
            {
                ItemType.Kamikaze => Instantiate(kamikaze, GetRandomPos(), Quaternion.identity),
                ItemType.Mine => Instantiate(mine, GetRandomPos(), Quaternion.identity),
                ItemType.HealthPotion => Instantiate(healthPot, GetRandomPos(), Quaternion.identity),
                ItemType.HomingRocket => Instantiate(homingRocket, GetRandomPos(), Quaternion.identity),
                _ => null
            };
            item.GetComponent<NetworkObject>().Spawn();
        }
    }

    private Vector3 GetRandomPos()
    {
        int randomX = (int)Random.Range(-boundX, boundX);
        int randomZ = (int)Random.Range(-boundZ, boundZ);

        return new Vector3(randomX, 0, randomZ);
    }
}