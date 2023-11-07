using System.Collections;
using _Game.Scripts.Base.AppState;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;
using UnityEngine;

namespace _Game.Scripts.Sequence.AppStates
{
    public class CounterState : AbstractAppState
    {
        private CounterUI counterUI;
        public override void Initialize()
        {
            counterUI=UIManager.Instance.GetCanvas(CanvasTypes.Counter) as CounterUI;
        }

        public override void Enter()
        {
            UIManager.Instance.EnableCanvas(CanvasTypes.Counter);
            StartCoroutine(Counter());
        }

        public override void Exit()
        {
            UIManager.Instance.DisableCanvas(CanvasTypes.Counter);
        }

        IEnumerator Counter()
        {
            for (int i = 3; i >= 1; i--)
            {
                counterUI.SetCounterText(i.ToString());
                yield return new WaitForSeconds(1f);
            }
            StartGame();
        }

        private void StartGame()
        {
            SequenceManager.Instance.ChangeState(AppStateTypes.InGame);
        }
    }
}
