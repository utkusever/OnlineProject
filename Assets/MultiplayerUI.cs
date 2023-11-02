using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Base.UserInterface;
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
        Debug.Log("Multiplayer Enabled");
    }
    public override void OnQuit()
    {
        serverButton.onClick.RemoveListener(HostGame);
        Debug.Log("Multiplayer Disabled");
    }
    private void HostGame()
    {
        ServerButton?.Invoke();
    }
    private void AddClient()
    {
        ClientButton?.Invoke();
    }

}
