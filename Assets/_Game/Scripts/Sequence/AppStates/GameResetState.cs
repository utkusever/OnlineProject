using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using UnityEngine;

namespace _Game.Scripts.Sequence.AppStates
{
    public class GameResetState : AbstractAppState
    {
        [SerializeField] private PlayerController playerController;

        public override void Enter()
        {
            UIManager.Instance.EnableCanvas(CanvasTypes.Loading);
            // playerController.ResetPlayer();
            SequenceManager.Instance.ChangeState(AppStateTypes.Loading);
        }

        public override void Exit()
        {
            UIManager.Instance.DisableCanvas(CanvasTypes.Loading);
        }
    }
}
