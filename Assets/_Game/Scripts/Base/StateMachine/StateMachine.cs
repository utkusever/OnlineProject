using System;

namespace _Game.Scripts.Base.StateMachine
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        public virtual void ChangeState(IState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (CurrentState != null)
                CurrentState.Exit();

            CurrentState = state;
            CurrentState.Enter();
        }
    }
}