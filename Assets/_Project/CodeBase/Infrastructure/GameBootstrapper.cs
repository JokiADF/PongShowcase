﻿using _Project.CodeBase.Infrastructure.States;
using _Project.CodeBase.Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }
        
        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<GameBootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameLoadingState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameplayState>());
            
            _gameStateMachine.Enter<GameBootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}