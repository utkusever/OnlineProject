using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;
using UnityEngine;

namespace _Game.Scripts.Sequence.AppStates
{
    public class LoadingState : AbstractAppState
    {
        [SerializeField] private float loadingTime;
        private LoadingUI loadingUI;
        public override void Initialize()
        {
            loadingUI = UIManager.Instance.GetCanvas(CanvasTypes.Loading) as LoadingUI;
        }
        public override void Enter()
        {
            loadingUI.LoadingTime = loadingTime;
            loadingUI.Activate();
            Invoke("ExitLoading", loadingTime);
        }

        public override void Exit()
        {
            UIManager.Instance.DisableCanvas(CanvasTypes.Loading);
        }

        private void ExitLoading()
        {
            SequenceManager.Instance.ChangeState(AppStateTypes.Multiplayer);
        }
    }
}
