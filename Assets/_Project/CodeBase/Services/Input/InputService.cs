using UnityEngine;

namespace _Project.CodeBase.Services.InputService
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }
        
        protected static Vector2 InputAxis() => 
            new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}