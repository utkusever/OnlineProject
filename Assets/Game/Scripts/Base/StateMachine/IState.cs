using System;

namespace _Game.Scripts.Base.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
