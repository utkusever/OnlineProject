using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.Sequence;
using _Game.Scripts.UserInterface;
using UnityEngine;

public class MultiplayerState : AbstractAppState
{ //TODO select server or client then change state
    private MultiplayerUI multiplayerUI;
    public override void Initialize()
    {
        multiplayerUI = UIManager.Instance.GetCanvas(CanvasTypes.Multiplayer) as MultiplayerUI;
        multiplayerUI.ServerButton += StartGameAsHost;
        multiplayerUI.ClientButton += StartGameAsClient;
    }
    public override void Enter()
    {
        multiplayerUI.Activate();
    }
    public override void Exit()
    {
        multiplayerUI.Deactivate();
    }
    private void StartGameAsHost()
    {
        SequenceManager.Instance.ChangeState(AppStateTypes.InGame);

    }
    private void StartGameAsClient()
    {
        SequenceManager.Instance.ChangeState(AppStateTypes.InGame);

    }

}
