using _Game.Scripts.Base.StateMachine;
using UnityEngine;

namespace _Game.Scripts.Base.AppState
{
    public abstract class AbstractAppState : MonoBehaviour , IState
    {
        public AppStateTypes appStateType;

        public virtual void Initialize()
        {
            
        }
        public virtual void Enter()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
