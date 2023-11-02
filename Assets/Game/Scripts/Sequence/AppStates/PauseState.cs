using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;

namespace _Game.Scripts.Sequence.AppStates
{
    public class PauseState : AbstractAppState
    {
        private PauseUI pauseUI;
        public override void Initialize()
        {
            pauseUI=UIManager.Instance.GetCanvas(CanvasTypes.Pause) as PauseUI;
            pauseUI.Reset += ResetGame;
            pauseUI.Resume += ResumeGame;
        }

        public override void Enter()
        {
            UIManager.Instance.EnableCanvas(CanvasTypes.Pause);
        }

        public override void Exit()
        {
            UIManager.Instance.DisableCanvas(CanvasTypes.Pause);
        }

        private void ResetGame()
        {
            SequenceManager.Instance.ChangeState(AppStateTypes.Reset);
        }

        private void ResumeGame()
        {
            SequenceManager.Instance.ChangeState(AppStateTypes.Counter);
        }
    }
}
