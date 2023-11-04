using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Base.UserInterface;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerUI : AbstractBaseCanvas
{
    [SerializeField] Button serverButton;
    public OnUIButtonClickEvent ServerButton;
    [SerializeField] Button clientButton;
    public OnUIButtonClickEvent ClientButton;

    public override void OnStart()
    {
        serverButton.onClick.AddListener(HostGame);
        clientButton.onClick.AddListener(AddClient);

        Debug.Log("Multiplayer Enabled");
    }

    public override void OnQuit()
    {
        serverButton.onClick.RemoveListener(HostGame);
        clientButton.onClick.RemoveListener(AddClient);

        Debug.Log("Multiplayer Disabled");
    }

    private void HostGame()
    {
        NetworkManager.Singleton.StartHost();
        ServerButton?.Invoke();
    }

    private void AddClient()
    {
        NetworkManager.Singleton.StartClient();
        ClientButton?.Invoke();
    }
}