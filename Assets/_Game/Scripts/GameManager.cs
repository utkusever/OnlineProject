using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;
    [SerializeField] BulletPool bulletPool;
    [SerializeField] private Generator generator;
    private Dictionary<ulong, PlayerController> clientsDictionary = new Dictionary<ulong, PlayerController>();

    public void OnConnectedToServer()
    {
        print("joined");
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public BulletPool GetBulletPool()
    {
        return bulletPool;
    }

    public Generator GetGenerator()
    {
        return generator;
    }

    [ServerRpc(RequireOwnership = false)]
    public void UpdateClientDictionaryServerRpc()
    {
        print("update client");
        if (!IsOwner)
        {
            return;
        }

        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            if (!clientsDictionary.ContainsKey(client.ClientId))
            {
                clientsDictionary.Add(client.ClientId, client.PlayerObject.GetComponent<PlayerController>());
                print(client.ClientId);
            }
        }
    }
}