﻿using Zenject;

namespace _Project.CodeBase.Infrastructure.States
{
    public class StatesFactory
    {
        private IInstantiator instantiator;

        public StatesFactory(IInstantiator instantiator) => 
            this.instantiator = instantiator;

        public TState Create<TState>() where TState : IExitableState => 
            instantiator.Instantiate<TState>();
    }
}