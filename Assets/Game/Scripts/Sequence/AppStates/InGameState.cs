using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;
using UnityEngine;

namespace _Game.Scripts.Sequence.AppStates
{
    public class InGameState : AbstractAppState
    {
        //[SerializeField] private PlayerController playerController;
        private InGameUI inGameUI;

        public override void Initialize()
        {
            inGameUI = UIManager.Instance.GetCanvas(CanvasTypes.InGame) as InGameUI;
            // inGameUI.Pause = PauseGame;
            //playerController.OnPositionChange += inGameUI.SetDistanceText;
        }

        public override void Enter()
        {
            //playerController.canControl = true;
            UIManager.Instance.EnableCanvas(CanvasTypes.InGame);
            GameManager.Instance.GetGenerator().GenerateItem(ItemType.Mine,5);
        }

        public override void Exit()
        {
            // playerController.canControl = false;
            //UIManager.Instance.DisableCanvas(CanvasTypes.InGame);
        }

        private void PauseGame()
        {
            SequenceManager.Instance.ChangeState(AppStateTypes.Pause);
        }
    }
}