using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;
using UnityEngine;

namespace _Game.Scripts.Sequence.AppStates
{
    public class InGameState : AbstractAppState
    {
        private InGameUI inGameUI;

        public override void Initialize()
        {
            inGameUI = UIManager.Instance.GetCanvas(CanvasTypes.InGame) as InGameUI;
           
        }

        public override void Enter()
        {
            UIManager.Instance.EnableCanvas(CanvasTypes.InGame);
            GameManager.Instance.GetGenerator().GenerateItem(ItemType.Mine,5);
        }

        public override void Exit()
        {
            //UIManager.Instance.DisableCanvas(CanvasTypes.InGame);
        }

        private void PauseGame()
        {
            SequenceManager.Instance.ChangeState(AppStateTypes.Pause);
        }
    }
}