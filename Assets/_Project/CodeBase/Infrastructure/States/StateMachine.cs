using System;
using System.Collections.Generic;

namespace _Project.CodeBase.Infrastructure.States
{
    public abstract class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();
        private IExitableState _activeState;

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void RegisterState<TState>(TState state) where TState : IExitableState =>
            _states.Add(typeof(TState), state);
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            
            var state = GetState<TState>();
            _activeState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}